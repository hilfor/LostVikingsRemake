using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerProgress
{
    private int level;
    public int Level
    {
        set { level = value; }
        get { return level; }
    }

    public PlayerProgress() { }
    public PlayerProgress(int level)
    {
        this.level = level;
    }


}
