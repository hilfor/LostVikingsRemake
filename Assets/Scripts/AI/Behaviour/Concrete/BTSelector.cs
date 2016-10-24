using UnityEngine;
using System.Collections.Generic;
using System;

public class BTSelector : IBTSelector
{
    private List<IBTNode> childNodes;

    public BTSelector()
    {
        this.childNodes = new List<IBTNode>();
    }

    public IBTSelector AppendNode(IBTNode node)
    {
        this.childNodes.Add(node);
        return this;
    }

    public bool Process(IContext context)
    {
        for (int i = 0; i < childNodes.Count; i++)
        {
            if (childNodes[i].Process(context))
            {
                return true;
            }
        }
        return false;
    }

}
