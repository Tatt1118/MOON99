using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private IGameState currentState;
    private UiManager _uiManager;
    //各ステートを登録
    private Dictionary<GameStateType, IGameState> states = new();

    public GameStateMachine(UiManager uiManager)
    {
        _uiManager = uiManager;
    }

    public void AddState(IGameState state)
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
