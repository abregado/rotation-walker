using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundIndicator : MonoBehaviour, IIndicate {

    private bool _state;

    public void Init() {
        SetState(false);
    }

    public void SetState(bool state) {
        foreach (var source in this.gameObject.GetComponents<AudioSource>())
        {
            if (state)
                source.Play();
            else
                source.Stop();
        }
    }
}
