using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;

namespace UnitCircle.MVVMApp.ViewModels
{
    public abstract partial class TrigViewModel : ViewModelBase
    {
        #region fields
        private int _rounds = 0;
        private int _newRounds = 0;
        private int _saveRounds = 0;
        private double _frequency = 1.0;
        private double _angle;
        protected List<Point> _wavePoints = new();
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
        public bool IsNewRound
        {
            get
            {
                var result = _rounds != _saveRounds;

                _saveRounds = _rounds;
                return result;
            }
        }
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
        public virtual void Tick()
        {
            Angle += Frequency * 0.1;

            // Update Sin Wave Data
            if (IsNewRound)
            {
                _newRounds++;
            }
            if (_newRounds >= 2)
            {
                _newRounds = 0;
                _wavePoints.Clear();
            }
            UpdateWavePoints();
            OnPropertyChanged(nameof(WaveGeometry));
        }
        protected abstract void UpdateWavePoints();
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
