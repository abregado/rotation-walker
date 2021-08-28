using UnityEngine;

public class LightIndicator : MonoBehaviour, IIndicate {
    private Light[] _lights;

    private bool _state;

    
    public void Init() {
        _lights = GetComponentsInChildren<Light>();
        
        StopEffects();
    }

    private void StartEffects() {
        foreach (var light in _lights) {
            light.enabled = true;
        }
    }

    private void StopEffects() {
        foreach (var light in _lights) {
            light.enabled = false;
        }
    }


    public void SetState(int state) {
        _state = state > 0;
        if (_state) {
            StartEffects();
        }
        else {
            StopEffects();
        }
    }

    public void SetState(bool state) {
        _state = state;
        if (_state) {
            StartEffects();
        }
        else {
            StopEffects();
        }
    }
}