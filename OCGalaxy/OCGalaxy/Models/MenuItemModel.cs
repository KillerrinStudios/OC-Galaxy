using Killerrin.Toolkit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OCGalaxy.Models
{
    public class MenuItemModel : ModelBase
    {
        private string _text = "";
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }

        private string _subtext = "";
        public string SubText
        {
            get => _subtext;
            set
            {
                _subtext = value;
                RaisePropertyChanged(nameof(SubText));
            }
        }

        private string _iconImageSource = "";
        public string IconImageSource
        {
            get => _iconImageSource;
            set
            {
                _iconImageSource = value;
                RaisePropertyChanged(nameof(IconImageSource));
            }
        }

        private ICommand _action = null;
        public ICommand Action
        {
            get => _action;
            set
            {
                _action = value;
                RaisePropertyChanged(nameof(Action));
            }
        }

        private bool _enabled = true;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                RaisePropertyChanged(nameof(Enabled));
            }
        }

        private bool _visible = true;
        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                RaisePropertyChanged(nameof(Visible));
            }
        }

        public MenuItemModel(string text, string subtext, string iconImageSource, ICommand action)
        {
            Text = text;
            SubText = subtext;
            IconImageSource = iconImageSource;
            Action = action;
        }
    }
}
