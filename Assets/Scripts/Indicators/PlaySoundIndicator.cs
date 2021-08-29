using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundIndicator : MonoBehaviour, IIndicate
{
    public bool playOnEnable = true;
    public bool playOnDisable = false;
    private bool _state = false;
    
    public void Init() {
        //SetState(false);
    }

    public void SetState(bool state) {
        if (state == _state)
            return;

        _state = state;
        
        foreach (var source in this.gameObject.GetComponents<AudioSource>())
        {
            if ((state && playOnEnable) || (!state && playOnDisable))
                source.Play();
            //else
            //    source.Stop();
        }
    }
}
