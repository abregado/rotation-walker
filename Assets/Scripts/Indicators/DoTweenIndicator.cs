using DG.Tweening;
using UnityEngine;

public class DoTweenIndicator: MonoBehaviour, IIndicate {

    private DOTweenAnimation[] _animations;
    private bool _internalState;
    
    public void Init() {
        _animations = GetComponents<DOTweenAnimation>();
        _internalState = false;
    }

    public void SetState(bool state) {
        if (_internalState != state) {
            _internalState = state;
            SetTweens();
        }
    }

    public void SetTweens() {
        foreach (DOTweenAnimation anim in _animations) {
            if (anim.id == "onChangeInOut") {
                if (_internalState) {
                    anim.DOPlayForwardById("onChangeInOut");
                }
                else {
                    anim.DOPlayBackwardsById("onChangeInOut");
                }
            } else if (anim.id == "onChangePlay") {
                anim.DORestartById("onChangePlay");
                anim.DOPlayForwardById("onChangePlay");
            } else if (anim.id == "whileTrue") {
                if (_internalState) {
                    anim.DOPlayForwardById("whileTrue");
                }
                else {
                    anim.DORestartById("whileTrue");
                    anim.DOPause();
                }
            } else if (anim.id == "onTruePlay") {
                anim.DOPlayForwardById("onTruePlay");
            } else if (anim.id == "onChangeIn") {
                if (_internalState) {
                    anim.DOPlayForwardById("onChangeIn");
                }
                else {
                    anim.DORestartById("onChangeIn");
                    anim.DOPause();
                }
            }
        }
    }

}