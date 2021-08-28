using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectBase: MonoBehaviour {
    private SetupHandler _handler;
    
    public Transform[] editorIndicators;
    private List<IIndicate> _indicators;
    
    public virtual void Init(SetupHandler handler) {
        _handler = handler;
        
        _indicators = new List<IIndicate>();

        foreach (Transform child in editorIndicators) {
            IIndicate indicator = child.GetComponent<IIndicate>();
            if (indicator != null) {
                _indicators.Add(indicator);
            }
        }
        
        
        foreach (IIndicate indicator in _indicators) {
            indicator.Init();
        }
    }

    public virtual void RoundStart() {
        
    }
    
    protected void SetIndicators(bool state) {
        foreach (IIndicate indicator in _indicators) {
            indicator.SetState(state);
        }
    }
}
