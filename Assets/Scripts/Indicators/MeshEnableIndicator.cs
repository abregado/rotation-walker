using UnityEngine;

public class MeshEnableIndicator: MonoBehaviour, IIndicate {

    private bool _state;
    public MeshRenderer target;

    public void Init() {
        SetState(false);
    }

    public void SetState(bool state) {
        _state = state;
        UpdateIndicatorVisuals();
    }

    private void UpdateIndicatorVisuals() {
        target.enabled = _state;
    }
}