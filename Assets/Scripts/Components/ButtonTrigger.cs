public class ButtonTrigger : BasicTrigger {
    
    public virtual void ToggleState() {
        this.SetTriggerables(!IsTriggered);
        SetIndicators(IsTriggered);
    }
}
