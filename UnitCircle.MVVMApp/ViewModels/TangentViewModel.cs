using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    public partial class TangentViewModel : TrigViewModel
    {
        protected override void UpdateWavePoints()
        {
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Math.Tan(Angle)));
            System.Diagnostics.Debug.WriteLine($"Tangens: {Math.Tan(Angle)}");
        }
    }
}
