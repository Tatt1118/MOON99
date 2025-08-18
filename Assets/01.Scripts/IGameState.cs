using UnityEngine;

public interface IGameState
{
    GameStateType StateType { get; }
    void Enter();
    void Exit();
    void Update();
}
