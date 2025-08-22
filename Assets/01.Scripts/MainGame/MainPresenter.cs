using UnityEngine;

public class MainPresenter
{
    private readonly MainView _view;
    private readonly MainModel _model;

    public MainPresenter(MainView view, MainModel model)
    {
        _view = view;
        _model = model;
        _view.SetUpButton(OnCharacterClick);
    }

    public void OnCharacterClick()
    {
        _view.DisplayText();
    }
}
