using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    /// <summary>
    /// Represents the main view model for the application, managing the state and behavior
    /// of the main window and its associated view models.
    /// </summary>
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        /// <summary>
        /// The frequency value that is shared across all sub-view models.
        /// </summary>
        private double _frequency;

        /// <summary>
        /// The timer used to periodically update the state of the view models.
        /// </summary>
        private DispatcherTimer _timer;

        /// <summary>
        /// The view model responsible for managing the tangent visualization.
        /// </summary>
        private readonly TangentViewModel _tangentViewModel = new();
        #endregion Fields

        #region Properties
        /// <summary>
        /// Gets the view model for the circle visualization.
        /// </summary>
        public CircleViewModel CircleViewModel { get; } = new();

        /// <summary>
        /// Gets the view model for the sinus visualization.
        /// </summary>
        public SinusViewModel SinusViewModel { get; } = new();

        /// <summary>
        /// Gets the view model for the cosinus visualization.
        /// </summary>
        public CosinusViewModel CosinusViewModel { get; } = new();

        /// <summary>
        /// Gets the view model for the tangent visualization.
        /// </summary>
        public TangentViewModel TangentViewModel { get; } = new();

        /// <summary>
        /// Gets or sets the frequency value, which is propagated to all sub-view models.
        /// </summary>
        public double Frequency
        {
            get => _frequency;
            set
            {
                _frequency = value;
                CircleViewModel.Frequency = value;
                SinusViewModel.Frequency = value;
                CosinusViewModel.Frequency = value;
                TangentViewModel.Frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class,
        /// setting up the timer and initializing the frequency.
        /// </summary>
        public MainWindowViewModel()
        {
            Frequency = 0.25;
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            _timer.Tick += (s, e) =>
            {
                CircleViewModel.Tick();
                SinusViewModel.Tick();
                CosinusViewModel.Tick();
                TangentViewModel.Tick();
            };
            _timer.Start();
        }

        /// <summary>
        /// Resets the state of all sub-view models to their initial state.
        /// </summary>
        [RelayCommand]
        public void Reset()
        {
            CircleViewModel.Reset();
            SinusViewModel.Reset();
            CosinusViewModel.Reset();
            TangentViewModel.Reset();
        }
        #endregion Methods
    }
}
