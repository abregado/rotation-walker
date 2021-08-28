using UnityEngine;

public class ActiveObjectBase: MonoBehaviour, IInit {
    private SetupHandler _handler;
    
    public virtual void Init(SetupHandler handler) {
        _handler = handler;
    }

    public virtual void RoundStart() {
        throw new System.NotImplementedException();
    }
}
