using UnityEngine;

public class ActiveObjectBase: MonoBehaviour, IInit {
    private SetupHandler _handler;
    
    public void Init(SetupHandler handler) {
        _handler = handler;
    }

    public void RoundStart() {
        throw new System.NotImplementedException();
    }
}
