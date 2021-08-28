using UnityEngine;
using UnityEngine.VFX;

public class ParticleIndicator : MonoBehaviour, IIndicate {
    private ParticleSystem[] _particleSystems;
    private VisualEffect[] _visualEffects;

    private bool _state;

    
    public void Init() {
        _particleSystems = GetComponentsInChildren<ParticleSystem>();
        _visualEffects = GetComponentsInChildren<VisualEffect>();

        SetState(false);
    }

    private void StartEffects() {
        foreach (var system in _particleSystems) {
            system.Play();
        }

        foreach (var effect in _visualEffects) {
            effect.Play();
        }
    }

    private void StopEffects() {
        
        foreach (ParticleSystem system in _particleSystems) {
            system.Stop();
            system.Clear();
        }
        
        foreach (VisualEffect effect in _visualEffects) {
            effect.Stop();
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