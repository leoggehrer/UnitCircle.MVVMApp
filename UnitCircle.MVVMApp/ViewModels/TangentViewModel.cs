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
            Value = Math.Tan(Angle);
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Value));
            System.Diagnostics.Debug.WriteLine($"Tangens: {Value}");
        }
    }
}
