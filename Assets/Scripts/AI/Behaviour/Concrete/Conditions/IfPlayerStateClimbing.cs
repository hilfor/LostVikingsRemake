using UnityEngine;
using System.Collections;
using System;

public class IfPlayerStateClimbing : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        State playerState = ((ICharacter)context.GetVariable("ICharacter")).GetState();
        return playerState.Climbing ;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);    }
}
