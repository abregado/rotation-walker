using UnityEngine;

public class SetupHandler : MonoBehaviour
{
    void Start() {
        ActiveObjectBase[] toBeInit = GameObject.FindObjectsOfType<ActiveObjectBase>();
        
        foreach (ActiveObjectBase activeObject in toBeInit) {
            activeObject.Init(this);
        }
        RoundStart();
    }

    public void RoundStart() {
        foreach (ActiveObjectBase activeObject in GameObject.FindObjectsOfType<ActiveObjectBase>()) {
            activeObject.RoundStart();
        }
    }
    
}
