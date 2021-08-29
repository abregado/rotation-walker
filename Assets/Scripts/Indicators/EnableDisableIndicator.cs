using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableIndicator: MonoBehaviour, IIndicate {

    private bool _state;
    public GameObject[] enable;
    public GameObject[] disable;

    public void Init() {
        SetState(false);
    }

    public void SetState(bool state) {
        _state = state;
        UpdateIndicatorVisuals();
    }

    private void UpdateIndicatorVisuals() {
        foreach (var target in enable)
            target.SetActive(_state);
        foreach (var target in disable)
            target.SetActive(!_state);
    }
}
