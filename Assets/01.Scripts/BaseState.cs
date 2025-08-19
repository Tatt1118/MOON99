using Unity.VisualScripting;

public abstract class BaseState
{
    protected StateMachine stateMachine;
    public abstract GameStateType StateType { get; }

    public BaseState(StateMachine machine)
    {
        this.stateMachine = machine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }

}
