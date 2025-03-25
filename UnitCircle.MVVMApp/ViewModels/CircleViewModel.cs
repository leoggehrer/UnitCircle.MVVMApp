using Avalonia.Media;
using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    /// <summary>
    /// Represents the view model for the circle visualization.
    /// </summary>
    public partial class CircleViewModel : ViewModelBase
    {
        #region fields
        private double _frequency = 1.0;
        private double _angle;
        private int _rounds = 0;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets or sets the angle in radians. When setting the angle, it ensures that the value
        /// </summary>
        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                Rounds = _angle >= Math.PI * 2 ? Rounds + 1 : Rounds;
                _angle %= Math.PI * 2;
                OnPropertyChanged(nameof(Angle));
            }
        }
        /// <summary>
        /// Gets or sets the frequency value, which determines the speed at which the angle is
        /// </summary>
        public double Frequency
        {
            get => _frequency;
            set
            {
                _frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }
        public int Rounds
        {
            get => _rounds;
            set
            {
                _rounds = value;
                OnPropertyChanged(nameof(Rounds));
            }
        }
        /// <summary>
        /// Gets the x-coordinate of the pointer on the circle.
        /// </summary>
        public double X => 200 + 100 * Math.Cos(-_angle);
        /// <summary>
        /// Gets the y-coordinate of the pointer on the circle.
        /// </summary>
        public double Y => 200 + 100 * Math.Sin(-_angle);

        /// <summary>
        /// Gets the geometry of the circle.
        /// </summary>
        public Geometry CircleGeometry { get; }
        /// <summary>
        /// Gets the geometry of the pointer on the circle.
        /// </summary>
        public Geometry PointerGeometry => new EllipseGeometry(new Rect(X - 5, Y - 5, 10, 10));
        /// <summary>
        ///  Gets the geometry of the line from the center to the pointer.
        /// </summary>
        public Geometry LineGeometry => new LineGeometry(new Point(200, 200), new Point(X, Y));
        #endregion properties

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleViewModel"/> class.
        /// </summary>
        public CircleViewModel()
        {
            CircleGeometry = new EllipseGeometry(new Rect(100, 100, 200, 200));
        }
        /// <summary>
        /// Updates the angle and the corresponding coordinates on the unit circle.
        /// </summary>
        public void Tick()
        {
            Angle += Frequency * 0.1;
            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
            OnPropertyChanged(nameof(PointerGeometry));
            OnPropertyChanged(nameof(LineGeometry));
        }
        /// <summary>
        /// Resets the angle and rounds to zero.
        /// </summary>
        public void Reset()
        {
            Angle = 0;
            Rounds = 0;
            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
            OnPropertyChanged(nameof(PointerGeometry));
            OnPropertyChanged(nameof(LineGeometry));
        }
    }
}
