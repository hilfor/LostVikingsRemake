using UnityEngine;
using System.Collections;

public class IfNotAlreadyAttacking : IBTCondition
{
    public IfNotAlreadyAttacking()
    {
        Debug.Log("Asdf");

    }
    public bool ConditionPassed(IContext context)
    {
        return !((ICharacter)context.GetVariable("ICharacter")).GetState().Attacking;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
