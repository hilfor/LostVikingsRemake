using UnityEngine;
using System.Collections;
using System;

public class DisplayClimbingDownAnimation : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.ClimbingDown);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
