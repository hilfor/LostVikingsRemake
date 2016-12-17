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
        this.childNodes.Add(node);
        return this;
    }

    public IExpectedBehavior ComposeBehavior(IContext context)
    {
        IExpectedBehavior expected = new ExpectedBehavior();

        for (int i = 0; i<childNodes.Count; i++)
        {
            if (childNodes[i] is IBTComposeableBehavior)
            {
                expected.Join(((IBTComposeableBehavior)childNodes[i]).ComposeBehavior(context));
            }else
            {
                childNodes[i].Process(context);
            }
        }

        return expected;

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
