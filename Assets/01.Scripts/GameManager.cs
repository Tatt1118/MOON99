using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
    private GameStateMachine _gameStateMachine;

    private void Start()
    {
        _gameStateMachine = new GameStateMachine(uiManager);
        _gameStateMachine.ChangeState(new MainState(uiManager));
    }

    private void Update()
    {
        _gameStateMachine.Update();
    }

}
