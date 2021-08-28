using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnableIndicator : MonoBehaviour, IIndicate
{
    private bool _state;
    public Camera target;
    public Camera mainCamera;

    public void Init()
    {
        SetState(false);
    }

    public void SetState(bool state) {
        _state = state;
        UpdateIndicatorVisuals();
    }

    private void UpdateIndicatorVisuals() {
        target.enabled = _state;
        mainCamera.enabled = !_state;
    }
}
