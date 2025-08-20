using UnityEngine;

public class CoffeeState : IGameState
{
    public GameStateType StateType => GameStateType.Coffee;
    private UiManager _uiManager;

    public CoffeeState(UiManager uiManager)
    {
        _uiManager = uiManager;
    }

    public void Enter()
    {
        _uiManager.ShowCoffeeUI();
    }

    public void Exit() { }
    public void Update() { }

}
