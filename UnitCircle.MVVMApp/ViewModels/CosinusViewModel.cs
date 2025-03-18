using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    public partial class CosinusViewModel : TrigViewModel
    {
        protected override void UpdateWavePoints()
        {
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Math.Cos(Angle)));
            System.Diagnostics.Debug.WriteLine($"Cosinus: {Math.Cos(Angle)}");
        }
    }
}
