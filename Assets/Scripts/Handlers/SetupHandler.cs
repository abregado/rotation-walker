using UnityEngine;

public class SetupHandler : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform) {
            IInit activeObject = child.GetComponent<IInit>();
            if (activeObject != null) {
                activeObject.Init(this);
            }
        }
        RoundStart();
    }

    public void RoundStart() {
        foreach (Transform child in transform) {
            IInit activeObject = child.GetComponent<IInit>();
            if (activeObject != null) {
                activeObject.RoundStart();
            }
        }
    }
    
}
