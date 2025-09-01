using System;
using UnityEngine;
using R3;
using Cysharp.Threading.Tasks;

public class MainState : IGameState
{
    public GameStateType StateType => GameStateType.MainGame;
    private readonly MainPresenter _mainPresenter;
    private readonly GameStateMachine _gameStateMachine;
    private NovelState _novelState;
    private readonly NovelPresenter _novelPresenter;
    private StateFactory stateFactory;

    public MainState(GameStateMachine gm)
    {
        this._gameStateMachine = gm;
    }

    public void Enter()
    {
        Debug.Log("Main");
        _gameStateMachine.UiManager.ShowMainUI();
        _mainPresenter.OnState
            .Subscribe(_ =>
            {
                _gameStateMachine.StartNovel();
            })
        .AddTo(this);


    }

    public void Exit() { }
    public void Update() { }

}
