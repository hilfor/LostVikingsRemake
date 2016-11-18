using UnityEngine;
using System.Collections;

public class IfNotAlreadyAttacking : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return !((ICharacter)context.GetVariable("ICharacter")).GetState().Attacking;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
