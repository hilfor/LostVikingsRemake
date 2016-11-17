using UnityEngine;
using System;

public class SetAnimationToFalling : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.Falling);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
