using System;
using UnityEngine;

[System.Serializable]
public class ButtonInfo
{
    public string name;
    public Action onClick;

    public ButtonInfo(string name, Action onClick)
    {
        this.name = name;
        this.onClick = onClick;
    }
}
