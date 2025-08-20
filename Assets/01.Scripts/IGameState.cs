using UnityEngine;

public interface IGameState
{
    public GameStateType StateType { get; }
    public void Enter() { }
    public void Exit() { }
    public void Update() { }
}
