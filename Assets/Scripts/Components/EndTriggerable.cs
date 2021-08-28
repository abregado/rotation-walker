using System.Collections.Generic;
using UnityEngine;

public class EndTriggerable: MonoBehaviour, ITriggerable, IInit {
    public int triggersNeeded;
    public Transform[] editorIndicators;
    private List<IIndicate> _indicators;
    private Dictionary<int, bool> _triggerStates;
    private bool _triggerState;
    public void Init(SetupHandler handler) {
        _triggerStates = new Dictionary<int, bool>();
        _indicators = new List<IIndicate>();

        foreach (Transform child in editorIndicators) {
            IIndicate indicator = child.GetComponent<IIndicate>();
            if (indicator != null) {
                _indicators.Add(indicator);
            }
        }
        
        _triggerState = false;
        
        foreach (IIndicate indicator in _indicators) {
            indicator.Init();
        }
        
        SetIndicators(_triggerState);
    }
    
    public void RoundStart() {
        
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

    private void SetIndicators(bool state) {
        foreach (IIndicate indicator in _indicators) {
            indicator.SetState(state);
        }
    }
}

