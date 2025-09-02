using System;
using UnityEngine;
using R3;
using Cysharp.Threading.Tasks;

public class MainState : IGameState
{
    public GameStateType StateType => GameStateType.MainGame;
    private MainPresenter _mainPresenter;
    private GameStateMachine _gameStateMachine;
    private NovelState _novelState;
    private readonly NovelPresenter _novelPresenter;
    private StateFactory stateFactory;
    private readonly CompositeDisposable _disposables = new CompositeDisposable();


    public MainState(GameStateMachine gm, MainPresenter presenter)
    {
        _gameStateMachine = gm;
        _mainPresenter = presenter;
    }

    public void Enter()
    {
        Debug.Log("Main");
        _gameStateMachine.uiManager.ShowMainUI();
        _mainPresenter.OnState
            .Subscribe(_ =>
            {
                _gameStateMachine.StartNovel();
            })
        .AddTo(_disposables);

    }

    public void Exit() { }
    public void Update() { }

}
