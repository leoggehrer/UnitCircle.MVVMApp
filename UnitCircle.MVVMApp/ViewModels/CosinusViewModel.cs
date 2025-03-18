﻿using Avalonia;
using System;

namespace UnitCircle.MVVMApp.ViewModels
{
    /// <summary>
    /// Represents the view model for the cosinus visualization.
    /// </summary>
    public partial class CosinusViewModel : TrigViewModel
    {
        /// <summary>
        /// Updates the wave points for the cosinus visualization.
        /// </summary>
        protected override void UpdateWavePoints()
        {
            _wavePoints.Add(new Point(_wavePoints.Count * 1, 100 - 50 * Math.Cos(Angle)));
            System.Diagnostics.Debug.WriteLine($"Cosinus: {Math.Cos(Angle)}");
        }
    }
}
