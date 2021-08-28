using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrigger : ActiveObjectBase, ITrigger
{
    public Transform[] editorTriggerables;
    public bool editorIsTriggered;
    
    public bool IsTriggered { get => editorIsTriggered; set => editorIsTriggered = value; }
    public List<ITriggerable> triggerables { get; set; }

    
    public override void Init(SetupHandler handler) { 
        base.Init(handler);
        this.TriggerInit(editorTriggerables);
    }

    public override void RoundStart() {
        this.SetTriggerables(IsTriggered);
        SetIndicators(IsTriggered);
    }
}
