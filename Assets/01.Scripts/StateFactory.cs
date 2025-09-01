using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class StateFactory
{
    private readonly UiManager uiManager;
    private MainView mainView;
    private MainModel mainModel;

    public IGameState CreateMainState(GameStateMachine gm)
    {
        return new MainState(gm);
    }

    public IGameState CreateNovelState(GameStateMachine gm)
    {
        return new NovelState(gm);
    }

}
