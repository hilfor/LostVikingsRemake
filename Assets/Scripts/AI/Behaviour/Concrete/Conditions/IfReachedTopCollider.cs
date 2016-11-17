public class IfReachedTopCollider : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).ReachedTopLadder();
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}