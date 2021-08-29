using UnityEngine;

public class MeshEnableIndicator: MonoBehaviour, IIndicate {

    private bool _state;
    public MeshRenderer target;
    public bool reversed;

    public void Init() {
        SetState(false);
    }

    public void SetState(bool state) {
        _state = state;
        UpdateIndicatorVisuals();
    }

    private void UpdateIndicatorVisuals() {
        if (reversed) {
            target.enabled = !_state;
            return;
        }
        target.enabled = _state;
    }
}