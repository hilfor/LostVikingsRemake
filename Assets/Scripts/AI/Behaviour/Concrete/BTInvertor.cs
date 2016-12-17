using UnityEngine;
using System.Collections;
using System;

public class BTInvertor : IBTInvertor
{
    private IBTNode childNode = null;

    public IBTInvertor SetNode(IBTNode node)
    {
        childNode = node;
        return this;
    }

    public bool Process(IContext context)
    {
        if (childNode != null)
        {
            return !childNode.Process(context);
        }
        return false;
    }

    public IExpectedBehavior ComposeBehavior(IContext context)
    {
        if (childNode != null)
        {
            if (childNode is IBTComposeableBehavior)
            {
                return ((IBTComposeableBehavior)childNode).ComposeBehavior(context);
            }
            childNode.Process(context);
        }
        return new ExpectedBehavior();

    }
}
