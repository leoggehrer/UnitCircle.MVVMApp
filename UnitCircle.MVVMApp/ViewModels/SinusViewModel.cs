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
            Value = Math.Sin(Angle);
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Value));
            System.Diagnostics.Debug.WriteLine($"Sinus: {Value}");
        }
    }
}
