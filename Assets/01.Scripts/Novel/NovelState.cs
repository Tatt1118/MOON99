using Unity.VisualScripting;
using UnityEngine;

public class NovelState : IGameState
{
    public GameStateType StateType => GameStateType.Novel;
    private readonly UiManager _uiManager;
    private readonly NovelPresenter _novelPresenter;
    private GameStateMachine _gameStateMachine;

    public NovelState(GameStateMachine gm, UiManager ui)
    {
        _gameStateMachine = gm;
        _uiManager = ui;
    }

    public void Enter()
    {
        _uiManager.ShowNovelUI();
    }
    public void Update() { }
    public void Exit() { }
}
