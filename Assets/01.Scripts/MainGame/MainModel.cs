using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel
{
    private StoryLineSO currentLine;

    public StoryLineSO CurrentLine => currentLine;

    //�Z���t��i�߂�
    public void Setline(StoryLineSO line) => currentLine = line;

    //�I�����̂���Ȃ�
    public bool HashChoices()
    {
        return currentLine.choices != null && currentLine.choices.Count > 0;
    }

    //�I���������ԂɎ��o��
    public IEnumerable<StoryChoice> GetChoices()//���ԂɎ��o���ӎv�\��
    {
        return currentLine.choices;
    }
}
