using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTrigger: ActiveObjectBase, ITrigger {
    public KeyCode activationKey;
    public Transform[] editorTriggerables;

    public bool IsTriggered { get; set; }
    public List<ITriggerable> triggerables { get; set; }

    
    public override void Init(SetupHandler handler) { 
        base.Init(handler);
        this.TriggerInit(editorTriggerables);
    }

    public override void RoundStart() {
        this.SetTriggerables(IsTriggered);
    }

    public void Update() {
        if (Input.GetKeyDown(activationKey)) {
            Debug.Log("button down");
            this.SetTriggerables(true);
            return;
        }

        if (Input.GetKeyUp(activationKey)) {
            Debug.Log("button up");
            this.SetTriggerables(false);
        }
    }
}
