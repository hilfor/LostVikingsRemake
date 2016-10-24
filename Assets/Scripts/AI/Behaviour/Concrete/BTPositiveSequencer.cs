using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BTPositiveSequencer : IBTPositiveSequencer
{

    private List<IBTNode> childNodes;

    public BTPositiveSequencer()
    {
        this.childNodes = new List<IBTNode>();

    }

    public IBTPositiveSequencer AppendNode(IBTNode node)
    {
        return this;
    }

    public bool Process(IContext context)
    {
        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].Process(context);
        }

        return true;
    }
}
