using System.Collections.Generic;
using UnityEngine;
using R3;

public class MainModel
{
	private StoryLineSO currentLine;
	private Dictionary<string, StoryLineSO> storyDictionary = new();

	// 現在のストーリーID
	private ReactiveProperty<string> currentStoryID = new();
	public ReadOnlyReactiveProperty<string> CurrentStoryID => currentStoryID;

	// 現在のセリフのインデックス
	private ReactiveProperty<int> currentIndex = new();
	public ReadOnlyReactiveProperty<int> CurrentIndex => currentIndex;

	// 現在のストーリーの参照:これによって読み取り専用にできる
	public StoryLineSO CurrentLine => currentLine;
	/* プロパティ式を使用しない場合
	public StoryLineSO CurrentLine
	{
			get
			{
					return currentLine;
			}
	}
	*/

	// 初期化
	public void Initialize(StoryLineSO[] stories)
	{
		storyDictionary.Clear();
		foreach (var story in stories)
		{
			//DictionaryにStoryIDを登録する。登録がなければ、追加する。
			if (!storyDictionary.ContainsKey(story.storyID))
				storyDictionary.Add(story.storyID, story);
		}

		// 最初のストーリーを設定
		if (stories.Length > 0)
		{
			SetStory(stories[0].storyID);
		}
	}

	// ストーリー設定
	public void SetStory(string storyID)
	{
		if (!storyDictionary.ContainsKey(storyID)) return;

		//スクリプタブルオブジェクトのStoryIDを今いるStoryIDにする
		currentLine = storyDictionary[storyID];
		//外部公開するようのストーリーがどこにいるかを通知するために必要
		currentStoryID.Value = storyID;
		currentIndex.Value = 0;
	}

	// 次のセリフへ進む
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
