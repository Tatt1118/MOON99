using Unity.VisualScripting;
using UnityEngine;

public class NovelState : IGameState
{
    public GameStateType StateType => GameStateType.Novel;
    private readonly UiManager _uiManager;
    private readonly NovelPresenter _novelPresenter;
    private GameStateMachine _gameStateMachine;

    public NovelState(GameStateMachine gm)
    {
        this._gameStateMachine = gm;
    }

    public void Enter()
    {
        _uiManager.ShowNovelUI();
        Debug.Log("ok");
    }
    public void Update() { }
    public void Exit() { }
}
