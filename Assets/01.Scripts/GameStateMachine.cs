using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private IGameState currentState;
    //各ステートを登録
    private Dictionary<GameStateType, BaseState> states = new();

    public void AddState(BaseState state)
    {
        states[state.StateType] = state;
    }
    
    public void ChangeState(IGameState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
