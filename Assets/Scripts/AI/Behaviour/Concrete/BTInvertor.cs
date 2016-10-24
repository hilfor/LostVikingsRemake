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
}
