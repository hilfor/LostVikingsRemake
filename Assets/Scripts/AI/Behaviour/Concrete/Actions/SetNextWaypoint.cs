
public class SetNextWaypoint : IBTAction
{
    public bool Act(IContext context)
    {
        IFollower follower = (IFollower)context.GetVariable("IFollower");
        follower.SetNextWaypoint(follower.GetNextWaypoint());
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
