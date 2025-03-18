using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    public partial class SinusViewModel : TrigViewModel
    {
        protected override void UpdateWavePoints()
        {
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Math.Sin(Angle)));
            System.Diagnostics.Debug.WriteLine($"Sinus: {Math.Sin(Angle)}");
        }
    }
}
