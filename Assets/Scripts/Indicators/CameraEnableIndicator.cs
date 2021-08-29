using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnableIndicator : MonoBehaviour, IIndicate
{
    private bool _state;
    public Camera target;
    public Camera mainCamera;
    public Canvas HUD;

    public void Init()
    {
        SetState(false);
    }

    public void SetState(bool state) {
        _state = state;
        UpdateIndicatorVisuals();
    }

    private void UpdateIndicatorVisuals() {
        target.gameObject.SetActive(_state);
        mainCamera.gameObject.SetActive(!_state);
        HUD.enabled = !_state;
    }
}
