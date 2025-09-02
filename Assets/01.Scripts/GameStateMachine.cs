using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private IGameState currentState;
    public UiManager uiManager { get; private set; }
    private StateFactory _stateFactory;
    private GameStateMachine stateMachine;

    //各ステートを登録
    private Dictionary<GameStateType, IGameState> states = new();

    public GameStateMachine(StateFactory stateFactory, UiManager ui)
    {
        _stateFactory = stateFactory;
        uiManager = ui;
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

    /// <summary>
    /// 次へ飛ぶときにこれを使う。
    /// </summary>
    public void StartNovel()
    {
        ChangeState(_stateFactory.CreateNovelState(stateMachine, uiManager));
    }
}
