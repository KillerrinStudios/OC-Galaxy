using Killerrin.Toolkit.Core.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace OCGalaxy.Models
{
    public class ToggleMenuItemModel : ModelBase
    {
        private MenuItemModel _onState = null;
        public MenuItemModel OnState
        {
            get => _onState;
            protected set
            {
                _onState = value;
                RaisePropertyChanged(nameof(OnState));

            }
        }

        private MenuItemModel _offState = null;
        public MenuItemModel OffState
        {
            get => _offState;
            protected set
            {
                _offState = value;
                RaisePropertyChanged(nameof(OffState));
            }
        }

        private MenuItemModel _currentState = null;
        public MenuItemModel CurrentState
        {
            get => _currentState;
            private set
            {
                _currentState = value;
                RaisePropertyChanged(nameof(CurrentState));
            }
        }

        public bool ToggleState { get; private set; } = false;
        public ICommand Toggle { get { return new Command(() => { ToggleCurrentState(); }); } }
        public ICommand Reset { get { return new Command(() => { SetCurrentState(); }); } }

        public ToggleMenuItemModel(bool currentState, MenuItemModel offState, MenuItemModel onState)
        {
            ToggleState = currentState;
            OffState = offState;
            OnState = onState;

            SetCurrentState();
        }

        public void ToggleCurrentState()
        {
            RaisePropertyChanging(nameof(ToggleState));
            ToggleState = !ToggleState;
            SetCurrentState();
            RaisePropertyChanged(nameof(ToggleState));

            CurrentState.Action?.Execute(null);
        }

        public void SetCurrentState()
        {
            if (ToggleState) { CurrentState = OnState; }
            else { CurrentState = OffState; }
        }
    }
}
