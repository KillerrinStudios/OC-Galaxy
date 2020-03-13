using Killerrin.Toolkit.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace OCGalaxy.ViewModels
{
    public abstract class OCViewModelBase : ModelBase
    {
        public virtual void Rotate(bool isClockwise) { Debug.WriteLine($"isClockwise={isClockwise}"); }
        public virtual void OnBackButtonPressed() { Debug.WriteLine($"OnBackButtonPressed"); }
    }
}
