using UnityEngine;
using System.Collections;
using System;

public class IfMovementNotRestricted : IBTCondition {
    public bool ConditionPassed(IContext context)
    {
        State characterState = ((ICharacter)context.GetVariable("ICharacter")).GetState();
        return characterState.CanClimb && characterState.CanMoveUp && characterState.CanMoveDown;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
