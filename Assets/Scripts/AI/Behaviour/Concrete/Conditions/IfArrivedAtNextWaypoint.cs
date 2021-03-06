﻿public class IfArrivedAtNextWaypoint : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        IFollower follower = (IFollower)context.GetVariable("IFollower");
        return follower.GetCurrentWaypoint().Reached((IWalker)follower);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
