using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class MainModel
{
    /// <summary>
    /// TODO:ScriptableObject�̏�������
    /// �EScriptableObject��StoryID�̊Ǘ�
    /// �@�@��CurrentStoryID���쐬
    /// �@�@
    /// 
    /// �E�����ɁA�X�g�[���[�iScriptableObject��Dialogue�j�����ׂďI�������A���̃X�g�[���[�iScriptableObject�j�֍s���悤�ɂ���
    /// 
    /// ���̂��߂ɂ́AScriptableObject�����X�g��������
    /// </summary>
    private StoryLineSO currentLine;

    //���݂̃X�g�[���[ID
    private ReactiveProperty<string> currentStoryID => new();
    public ReadOnlyReactiveProperty<string> CurrentStoryID => currentStoryID;//�O�����J

    //���݂̍s�C���f�b�N�X�F�{�^���������ꂽ�玟�̃e�L�X�g�Ɉڂ�
    private ReactiveProperty<int> currentIndex => new();
    public ReadOnlyReactiveProperty<int> CurrentIndex => currentIndex;//�O�����J

    //StoryID
    private Dictionary<string, StoryLineSO> storyDictionary;
    private List<StoryLineSO> storyList = new();

    //����`�F�b�N
    public StoryLineSO CurrentLine => currentLine;

    //�Z���t��i�߂�
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
    /// �X�g�[���[�̐ݒ�
    /// </summary>
    /// <param name="storyID"></param>
    public void SetStory(string storyID)
    {
        if (!storyDictionary.ContainsKey(storyID)) return; //�L�[���Ȃ��Ȃ�
        currentLine = storyDictionary[storyID];
        currentStoryID.Value = storyID;
        currentIndex.Value = 0;
    }

    /// <summary>
    /// ���̃Z���t�ɂ��������EDialogue�̊Ǘ��@�{�^���������ꂽ��
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
