using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : BasicTrigger {
    
    public void ToggleState() {
        this.SetTriggerables(!IsTriggered);
        SetIndicators(IsTriggered);
    }
}
