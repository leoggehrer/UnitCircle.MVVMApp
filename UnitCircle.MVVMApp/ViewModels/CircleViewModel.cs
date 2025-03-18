using Avalonia.Media;
using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    public partial class CircleViewModel : ViewModelBase
    {
        #region fields
        private double _frequency = 1.0;
        private double _angle;
        private int _rounds = 0;
        #endregion fields

        #region properties
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

        public double X => 200 + 100 * Math.Cos(-_angle);
        public double Y => 200 + 100 * Math.Sin(-_angle);

        public Geometry CircleGeometry { get; }
        public Geometry PointerGeometry => new EllipseGeometry(new Rect(X - 5, Y - 5, 10, 10));
        public Geometry LineGeometry => new LineGeometry(new Point(200, 200), new Point(X, Y));
        #endregion properties

        public CircleViewModel()
        {
            CircleGeometry = new EllipseGeometry(new Rect(100, 100, 200, 200));
        }

        public void Tick()
        {
            Angle += Frequency * 0.1;
            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
            OnPropertyChanged(nameof(PointerGeometry));
            OnPropertyChanged(nameof(LineGeometry));
        }

        public void Reset()
        {
            Angle = 0;
            Rounds = 0;
        }
    }
}
