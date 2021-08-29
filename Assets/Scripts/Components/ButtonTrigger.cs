public class ButtonTrigger : BasicTrigger {
    
    public virtual void ToggleState() {
        this.SetTriggerables(!IsTriggered);
        SetIndicators(IsTriggered);
    }

    public virtual bool Interactable()
    {
        return true;
    }
}
