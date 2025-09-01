using UnityEngine;
using R3;
using System;

public class MainPresenter
{
    private readonly MainView _view;
    private readonly MainModel _model;
    private readonly UiManager _uiManager;

    private Subject<Unit> _onChangeState = new();
    public Observable<Unit> OnState => _onChangeState;

    public MainPresenter(MainView view, MainModel model)
    {
        _view = view;
        _model = model;

        // ScriptableObjectのリストをModelに渡して初期化
        _model.Initialize(_view.StoryLineSO);

        // ボタンセットアップ
        _view.SetUpButton(OnCharacterClick);

        // ReactiveProperty購読
        _model.CurrentIndex
            .Subscribe(index =>
            {
                // 現在の台詞を取得
                var line = _model.CurrentLine.dialogues[index];

                // Viewに渡して表示
                _view.DisplayText(line.characterName, line.dialogue);
                Debug.Log(index);
            });
    }




    public void OnCharacterClick()
    {
        _onChangeState.OnNext(Unit.Default);

        // 次のセリフへ進む
        if (!_model.NextLine())
        {
            Debug.Log("このストーリーは最後まで到達しました");
        }
    }
}
