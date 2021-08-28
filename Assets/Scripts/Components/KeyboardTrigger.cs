using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTrigger: ActiveObjectBase, ITrigger {
    public KeyCode activationKey;
    public bool IsTriggered;
    public Transform[] editorTriggerables;
    
    private List<ITriggerable> _triggerables;

    
    public override void Init(SetupHandler handler) {
        base.Init(handler);
        _triggerables = new List<ITriggerable>();
        
        foreach (Transform obj in editorTriggerables) {
            ITriggerable triggerable = obj.GetComponent<ITriggerable>();
            if (triggerable != null) {
                _triggerables.Add(triggerable);
            }
        }
    }

    public override void RoundStart() {
        SetTriggerables(false);
    }

    private void SetTriggerables(bool state) {
        IsTriggered = state;
        if (state) {
            foreach (ITriggerable triggerable in _triggerables) {
                triggerable.SetOn(this);
            }

            return;
        }
        foreach (ITriggerable triggerable in _triggerables) {
            triggerable.SetOff(this);
        }
        
    }

    public void Update() {
        if (Input.GetKeyDown(activationKey)) {
            Debug.Log("button down");
            SetTriggerables(true);
            return;
        }

        if (Input.GetKeyUp(activationKey)) {
            Debug.Log("button up");
            SetTriggerables(false);
        }
    }
}
