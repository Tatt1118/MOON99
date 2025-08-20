using UnityEngine;

public class MainState : IGameState
{
    public GameStateType StateType => GameStateType.MainGame;
    private readonly UiManager _uiManager;

    public MainState(UiManager uiManager)
    {
        _uiManager = uiManager;
    }

    public void Enter()
    {
        _uiManager.ShowMainUI();
    }

    public void Exit() { }
    public void Update() { }

}
