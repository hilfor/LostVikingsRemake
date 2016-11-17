using UnityEngine;
using System.Collections;

public class MoveThePlayerUpTheLadder : IBTAction
{
    public bool Act(IContext context)
    {
        IWalker walker = (IWalker)context.GetVariable("IWalker");
        walker.MoveUp(walker.GetWalkerSpeed());
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
