using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrigger : ActiveObjectBase, ITrigger
{
    public Transform[] editorTriggerables;
    public bool editorIsTriggered;
    
    public Transform[] editorIndicators;
    private List<IIndicate> _indicators;

    public bool IsTriggered { get => editorIsTriggered; set => editorIsTriggered = value; }
    public List<ITriggerable> triggerables { get; set; }

    
    public override void Init(SetupHandler handler) { 
        base.Init(handler);
        
        this.TriggerInit(editorTriggerables);
        
        _indicators = new List<IIndicate>();

        foreach (Transform child in editorIndicators) {
            IIndicate indicator = child.GetComponent<IIndicate>();
            if (indicator != null) {
                _indicators.Add(indicator);
            }
        }
        
        Debug.Log("indicator count " + _indicators.Count);
        
        foreach (IIndicate indicator in _indicators) {
            indicator.Init();
        }
        
    }

    public override void RoundStart() {
        this.SetTriggerables(IsTriggered);
        SetIndicators(IsTriggered);
    }
    
    protected void SetIndicators(bool state) {
        Debug.Log("Setting indicator states on trigger");
        foreach (IIndicate indicator in _indicators) {
            indicator.SetState(state);
        }
    }
}
