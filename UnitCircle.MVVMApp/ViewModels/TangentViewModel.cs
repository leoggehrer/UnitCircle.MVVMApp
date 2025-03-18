using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    /// <summary>
    /// Represents the view model for the tangent visualization.
    /// </summary>
    public partial class TangentViewModel : TrigViewModel
    {
        /// <summary>
        /// Updates the wave points for the tangent visualization.
        /// </summary>
        protected override void UpdateWavePoints()
        {
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Math.Tan(Angle)));
            System.Diagnostics.Debug.WriteLine($"Tangens: {Math.Tan(Angle)}");
        }
    }
}
