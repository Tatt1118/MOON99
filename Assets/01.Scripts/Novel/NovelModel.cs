using R3;
using System.Collections.Generic;
using UnityEngine;

public class NovelModel
{
    private StoryLineSO currentLine;
    private Dictionary<string, StoryLineSO> storyDictionary = new();

    public StoryLineSO CurrentLine => currentLine;
    //public StoryLineSO CurrentLine
    //{
    //    get
    //    {
    //        return currentLine;
    //    }
    //}

    private ReactiveProperty<string> currentStoryID = new();
    public ReadOnlyReactiveProperty<string> CurrentStoryID => currentStoryID;

    private ReactiveProperty<int> currentIndex = new();
    public ReadOnlyReactiveProperty<int> CurrentIndex => currentIndex;

    public void Initialize(StoryLineSO[] stories)
    {
        storyDictionary.Clear();
        foreach (var story in stories)
        {
            if (!storyDictionary.ContainsKey(story.storyID))
                storyDictionary.Add(story.storyID, story);
        }

        if (stories.Length > 0)
        {
            SetStory(stories[0].storyID);
        }
    }


    public void SetStory(string storyID)
    {
        if (!storyDictionary.ContainsKey(storyID)) return;
        currentLine = storyDictionary[storyID];
        currentStoryID.Value = storyID;
        currentIndex.Value = 0;

    }

}
