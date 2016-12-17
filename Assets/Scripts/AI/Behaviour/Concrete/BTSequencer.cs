using UnityEngine;
using System;
using System.Collections.Generic;
public class BTSequencer : IBTSequencer
{

    private List<IBTNode> childNodes;

    public BTSequencer()
    {
        this.childNodes = new List<IBTNode>();
    }

    public IBTSequencer AppendNode(IBTNode node)
    {
        this.childNodes.Add(node);
        return this;
    }

    public bool Process(IContext context)
    {
        for (int i = 0; i < childNodes.Count; i++)
        {
            if (!childNodes[i].Process(context))
            {
                return false;
            }
        }

        return true;
    }

}
