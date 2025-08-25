using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class MainModel
{
    /// <summary>
    /// TODO:ScriptableObjectの情報を入れる
    /// ・ScriptableObjectのStoryIDの管理
    /// 　　⇒CurrentStoryIDを作成
    /// 　　
    /// 
    /// ・ここに、ストーリー（ScriptableObjectのDialogue）がすべて終わったら、次のストーリー（ScriptableObject）へ行くようにする
    /// 
    /// そのためには、ScriptableObjectをリスト化させる
    /// </summary>
    private StoryLineSO currentLine;

    //現在のストーリーID
    private ReactiveProperty<string> currentStoryID => new();
    public ReadOnlyReactiveProperty<string> CurrentStoryID => currentStoryID;//外部公開

    //現在の行インデックス：ボタンが押されたら次のテキストに移る
    private ReactiveProperty<int> currentIndex => new();
    public ReadOnlyReactiveProperty<int> CurrentIndex => currentIndex;//外部公開

    //StoryID
    private Dictionary<string, StoryLineSO> storyDictionary;
    private List<StoryLineSO> storyList = new();

    //分岐チェック
    public StoryLineSO CurrentLine => currentLine;

    //セリフを進める
    public void Setline(StoryLineSO line) => currentLine = line;

    public void Initialize(List<StoryLineSO> stories)
    {
        storyDictionary = new Dictionary<string, StoryLineSO>();
        foreach (var story in stories)
        {
            storyDictionary[story.storyID] = story;
            storyList.Add(story);
        }

        if (storyList.Count > 0)
            SetStory(storyList[0].storyID);
    }

    /// <summary>
    /// ストーリーの設定
    /// </summary>
    /// <param name="storyID"></param>
    public void SetStory(string storyID)
    {
        if (!storyDictionary.ContainsKey(storyID)) return; //キーがないなら
        currentLine = storyDictionary[storyID];
        currentStoryID.Value = storyID;
        currentIndex.Value = 0;
    }

    /// <summary>
    /// 次のセリフにいく処理・Dialogueの管理　ボタンが押されたら
    /// </summary>
    /// <returns></returns>
    public bool NextLine()
    {
        if (currentLine == null || currentLine.dialogues == null) return false;

        if (currentIndex.CurrentValue + 1 < currentLine.dialogues.Count)
        {
            currentIndex.Value++;
            return true;
        }
        else return false;
    }

    public void GoToNextStory(string nextStoryID)
    {
        SetStory(nextStoryID);
    }
}
