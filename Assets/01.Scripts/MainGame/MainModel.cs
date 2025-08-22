using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel
{
    private StoryLineSO currentLine;

    public StoryLineSO CurrentLine => currentLine;

    //セリフを進める
    public void Setline(StoryLineSO line) => currentLine = line;

    //選択肢のあるなし
    public bool HashChoices()
    {
        return currentLine.choices != null && currentLine.choices.Count > 0;
    }

    //選択肢を順番に取り出す
    public IEnumerable<StoryChoice> GetChoices()//順番に取り出す意思表示
    {
        return currentLine.choices;
    }
}
