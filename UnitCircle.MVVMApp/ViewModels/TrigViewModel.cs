using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;

namespace UnitCircle.MVVMApp.ViewModels
{
    public abstract partial class TrigViewModel : ViewModelBase
    {
        #region fields
        private double _value;
        private int _rounds = 0;
        private int _newRounds = 0;
        private int _saveRounds = 0;
        private double _frequency = 1.0;
        private double _angle;
        /// <summary>
        /// The list of points that make up the wave visualization.
        /// </summary>
        protected List<Point> _wavePoints = new();
        #endregion fields

        #region properties
        /// <summary>
        /// Gets or sets the value of the trigonometric function at the current angle.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        /// <summary>
        /// Gets or sets the angle value, which determines the position on the unit circle.
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
        /// <summary>
        /// Gets or sets the number of full rotations that have been completed.
        /// </summary>
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
        /// Gets the X-coordinate of the point on the unit circle corresponding to the current angle.
        /// </summary>
        public bool IsNewRound
        {
            get
            {
                var result = _rounds != _saveRounds;

                _saveRounds = _rounds;
                return result;
            }
        }
        /// <summary>
        /// Gets the Y-coordinate of the point on the unit circle corresponding to the current angle.
        /// </summary>
        public StreamGeometry WaveGeometry
        {
            get
            {
                var geometry = new StreamGeometry();
                using (var ctx = geometry.Open())
                {
                    if (_wavePoints.Count > 1)
                    {
                        ctx.BeginFigure(_wavePoints[0], false);
                        for (int i = 1; i < _wavePoints.Count; i++)
                        {
                            ctx.LineTo(_wavePoints[i]);
                        }
                    }
                }
                return geometry;
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Updates the angle and the wave points based on the current angle and frequency.
        /// </summary>
        public virtual void Tick()
        {
            int clearRounds = (int)(Frequency / 0.5) * 2 + 1;
            Angle += Frequency * 0.1;

            // Update Sin Wave Data
            if (IsNewRound)
            {
                _newRounds++;
            }
            if (_newRounds >= clearRounds)
            {
                _newRounds = 0;
                _wavePoints.Clear();
            }
            UpdateWavePoints();
            OnPropertyChanged(nameof(WaveGeometry));
        }
        /// <summary>
        /// Updates the wave points based on the current angle.
        /// </summary>
        protected abstract void UpdateWavePoints();
        /// <summary>
        /// Resets the angle and the number of rounds to zero.
        /// </summary>
        public void Reset()
        {
            _newRounds = 0;
            _saveRounds = 0;
            Angle = 0;
            Rounds = 0;
            _wavePoints.Clear();
            OnPropertyChanged(nameof(WaveGeometry));
        }
        #endregion methods
    }
}
