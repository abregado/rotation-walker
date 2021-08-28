using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{ 
    public bool IsTriggered { get; set; }
    public List<ITriggerable> triggerables { get; set; }
}

public static class ITriggerExtensions
{
    public static void TriggerInit(this ITrigger trigger, Transform[] editorTriggerables)
    {
        trigger.triggerables = new List<ITriggerable>();
        
        foreach (Transform obj in editorTriggerables) {
            ITriggerable triggerable = obj.GetComponent<ITriggerable>();
            if (triggerable != null) {
                trigger.triggerables.Add(triggerable);
            }
        }
    }
    
    public static void SetTriggerables(this ITrigger trigger, bool state) {
        trigger.IsTriggered = state;
        if (state) {
            foreach (ITriggerable triggerable in trigger.triggerables) {
                triggerable.SetOn(trigger);
            }
            return;
        }
        foreach (ITriggerable triggerable in trigger.triggerables) {
            triggerable.SetOff(trigger);
        }
    }
}
