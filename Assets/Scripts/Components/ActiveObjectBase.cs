using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectBase: MonoBehaviour {
    
    [Header("ActiveObject")]
    public Transform[] editorIndicators;
    
    private List<IIndicate> _unlockedIndicators;
    private SetupHandler _handler;
    public virtual void Init(SetupHandler handler) {
        _handler = handler;
        
        _unlockedIndicators = new List<IIndicate>();

        foreach (Transform child in editorIndicators) {
            IIndicate indicator = child.GetComponent<IIndicate>();
            if (indicator != null) {
                _unlockedIndicators.Add(indicator);
            }
        }
        
        
        foreach (IIndicate indicator in _unlockedIndicators) {
            indicator.Init();
        }
    }

    public virtual void RoundStart() {
        
    }
    
    protected void SetIndicators(bool state) {
        foreach (IIndicate indicator in _unlockedIndicators) {
            indicator.SetState(state);
        }
    }
}
