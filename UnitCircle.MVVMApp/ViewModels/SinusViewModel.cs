using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    /// <summary>
    /// Represents the view model for the sinus visualization.
    /// </summary>
    public partial class SinusViewModel : TrigViewModel
    {
        /// <summary>
        /// Updates the wave points for the sinus visualization.
        /// </summary>
        protected override void UpdateWavePoints()
        {
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Math.Sin(Angle)));
            System.Diagnostics.Debug.WriteLine($"Sinus: {Math.Sin(Angle)}");
        }
    }
}
