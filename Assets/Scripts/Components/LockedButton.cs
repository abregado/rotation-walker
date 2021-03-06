using System.Collections.Generic;
using UnityEngine;

namespace Components {
    public class LockedButton: ButtonTrigger, ITriggerable {
        
        [Header("IItriggerable")]
        public int triggersNeeded;
        private Dictionary<int, bool> _triggerStates;
        private bool _triggerState;

        [Header("LockedButton")]
        public Transform[] editorUnlockedIndicators;
        public bool latching;
        private List<IIndicate> _unlockedIndicators; 

        public override void Init(SetupHandler handler) {
            base.Init(handler);
            
            _unlockedIndicators = new List<IIndicate>();

            foreach (Transform child in editorUnlockedIndicators) {
                IIndicate indicator = child.GetComponent<IIndicate>();
                if (indicator != null) {
                    _unlockedIndicators.Add(indicator);
                }
            }
            
            
            foreach (IIndicate indicator in _unlockedIndicators) {
                indicator.Init();
            }
            
            _triggerStates = new Dictionary<int, bool>();
            _triggerState = false;
        }

        public override void ToggleState() {
            if (!Interactable())
                return;
            
            base.ToggleState(); 
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
            if (IsTriggered && latching) {
                return;
            }
            
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
                    SetUnlockedIndicators(true);
                    return;
                } 
                SetUnlockedIndicators(false);
            }
        }
        
        private void SetUnlockedIndicators(bool state) {
            foreach (IIndicate indicator in _unlockedIndicators) {
                indicator.SetState(state);
            }
        }
        
        public override bool Interactable()
        {
            if (IsTriggered && latching) {
                return false;
            }

            return _triggerState;
        }
    }
}