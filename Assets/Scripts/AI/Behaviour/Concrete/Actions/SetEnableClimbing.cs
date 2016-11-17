public class SetEnableClimbing : IBTAction
{
    public bool Act(IContext context)
    {
        ((IPlayer)context.GetVariable("IPlayer")).SetCanClimb(true);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}