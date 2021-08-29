using UnityEngine;

public class MaterialChangeIndicator: MonoBehaviour, IIndicate {
    private bool _state;
    private MeshRenderer _stateRenderer;
    public Material trueMaterial;
    public Material falseMaterial;
    public GameObject target;

    public void Init() {
        _stateRenderer = target.GetComponent<MeshRenderer>();    
        Debug.Assert(_stateRenderer != null,"MaterialChangeIndicators require one child named State");
        SetState(false);
    }

    public void SetState(bool state) {
        _state = state;
        UpdateIndicatorVisuals();
    }

    private void UpdateIndicatorVisuals() {
        if (_state && trueMaterial) {
            _stateRenderer.material = trueMaterial;
            return;
        }

        if (falseMaterial) {
            _stateRenderer.material = falseMaterial;
        }
    }
}