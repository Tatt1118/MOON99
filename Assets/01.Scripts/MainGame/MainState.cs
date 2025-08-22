using System;
using UnityEngine;

public class MainState : IGameState
{
    public GameStateType StateType => GameStateType.MainGame;
    private readonly UiManager _uiManager;
    private readonly MainPresenter _mainPresenter;

    public MainState(MainPresenter presenter, UiManager uiManager)
    {
        _uiManager = uiManager;
        _mainPresenter = presenter;
    }

    public void Enter()
    {
        _uiManager.ShowMainUI();

    }

    public void Exit() { }
    public void Update() { }

}
