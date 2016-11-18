public class IfReachedBottomCollider : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).ReachedBottomLadder();
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}