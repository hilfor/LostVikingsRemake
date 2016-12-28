public class IfWithin2HorizontalColliders : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        if (((ICharacter)context.GetVariable("ICharacter")).GetState().WithinLadderBounds)
        {
            return true;
        }
        return false;
        //return ((ICharacter)context.GetVariable("ICharacter")).GetState().WithinLadderBounds;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}