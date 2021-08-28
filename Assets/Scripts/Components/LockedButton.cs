using System.Collections.Generic;

namespace Components {
    public class LockedButton: ButtonTrigger, ITriggerable {
        public int triggersNeeded;
    
        private Dictionary<int, bool> _triggerStates;
        private bool _triggerState;

        private IIndicate[] _triggeredIndicators; 

        public override void Init(SetupHandler handler) {
            base.Init(handler);
            _triggerStates = new Dictionary<int, bool>();
            _triggerState = false;
        }

        public override void ToggleState() {
            if (_triggerState) {
                base.ToggleState();    
            }
        }

        public void SetOn(ITrigger trigger) {
            int hash = trigger.GetHashCode();
            if (_triggerStates.ContainsKey(hash)) {
                if (_triggerStates[hash] != true) {
                    _triggerStates[hash] = true;
                    CheckForStateChange();
                }
            }
            else {
                _triggerStates.Add(hash,true);
                CheckForStateChange();
            }
        }

        public void SetOff(ITrigger trigger) {
            int hash = trigger.GetHashCode();
            if (_triggerStates.ContainsKey(hash)) {
                if (_triggerStates[hash] != false) {
                    _triggerStates[hash] = false;
                    CheckForStateChange();
                }
            }
            else {
                _triggerStates.Add(hash,false);
                CheckForStateChange();
            }
        }
        
        protected virtual void CheckForStateChange() {
            int count = 0;
            foreach (var pair in _triggerStates) {
                if (pair.Value) {
                    count++;
                }
            }

            bool result = count >= triggersNeeded;
            if (result != _triggerState) {
                _triggerState = result;
                if (_triggerState) {
                    SetIndicators(true);
                    return;
                } 
                SetIndicators(false);
            }
        }
    }
}