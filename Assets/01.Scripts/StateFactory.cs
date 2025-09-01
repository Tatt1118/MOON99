using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class StateFactory
{
    private readonly UiManager uiManager;
    private MainView mainView;
    private MainModel mainModel;
    private MainPresenter mainPresenter;

    public IGameState CreateMainState(GameStateMachine gm)
    {
        // var mainPresenter = new MainPresenter(mainView, mainModel);
        return new MainState(gm, mainPresenter);
    }

    public IGameState CreateNovelState(GameStateMachine gm, UiManager ui)
    {
        return new NovelState(gm, ui);
    }
}
