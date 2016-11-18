using UnityEngine;
using System;

public class SetAnimationToWalkingLeft : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.Walking);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
