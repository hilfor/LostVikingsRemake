using UnityEngine;
using System.Collections;
using System;

public class BTRoot : IBTRoot
{
    private IBTNode node;

    public BTRoot(IBTNode node)
    {
        this.node = node;
    }

    public IExpectedBehavior GetExpectedBehavior(IContext context)
    {
        node.Process(context);
        throw new NotImplementedException();
    }
}
