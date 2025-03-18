using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region fields
        private double _frequency;
        private DispatcherTimer _timer;
        private CircleViewModel _circleViewModel = new CircleViewModel();
        private SinusViewModel _sinusViewModel = new SinusViewModel();
        private CosinusViewModel _cosinusViewModel = new CosinusViewModel();
        private TangentViewModel _tangentViewModel = new TangentViewModel();
        #endregion fields

        public CircleViewModel CircleViewModel
        {
            get => _circleViewModel;
            set
            {
                _circleViewModel = value;
                OnPropertyChanged(nameof(CircleViewModel));
            }
        }
        public SinusViewModel SinusViewModel
        {
            get => _sinusViewModel;
            set
            {
                _sinusViewModel = value;
                OnPropertyChanged(nameof(SinusViewModel));
            }
        }
        public CosinusViewModel CosinusViewModel
        {
            get => _cosinusViewModel;
            set
            {
                _cosinusViewModel = value;
                OnPropertyChanged(nameof(CosinusViewModel));
            }
        }
        public TangentViewModel TangentViewModel
        {
            get => _tangentViewModel;
            set
            {
                _tangentViewModel = value;
                OnPropertyChanged(nameof(TangentViewModel));
            }
        }
        #region properties
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
        #endregion properties

        public MainWindowViewModel()
        {
            Frequency = 0.5;
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

        [RelayCommand]
        public void Reset()
        {
            CircleViewModel.Reset();
            SinusViewModel.Reset();
            CosinusViewModel.Reset();
            TangentViewModel.Reset();
        }
    }
}
