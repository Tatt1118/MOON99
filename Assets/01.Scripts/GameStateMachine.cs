using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private IGameState currentState;
    public UiManager _uiManager { get; private set; }
    private StateFactory _stateFactory;

    //各ステートを登録
    private Dictionary<GameStateType, IGameState> states = new();

    public GameStateMachine(StateFactory stateFactory, UiManager uiManager)
    {
        _stateFactory = stateFactory;
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

    public void StartNovel()
    {
        ChangeState(_stateFactory.CreateNovelState(this));
    }


}
