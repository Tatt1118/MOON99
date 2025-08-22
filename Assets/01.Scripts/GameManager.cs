using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
    [SerializeField] MainView _mainView;
    private GameStateMachine _gameStateMachine;
    private MainPresenter _mainPresenter;
    private MainModel _mainModel;

    private void Start()
    {
        _mainModel = new MainModel();
        _mainPresenter = new MainPresenter(_mainView, _mainModel);

        _gameStateMachine = new GameStateMachine(uiManager);
        _gameStateMachine.ChangeState(new MainState(_mainPresenter, uiManager));
    }

    private void Update()
    {
        _gameStateMachine.Update();
    }
}
