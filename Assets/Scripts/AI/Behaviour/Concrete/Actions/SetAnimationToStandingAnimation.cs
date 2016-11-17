using UnityEngine;
using System;

public class SetAnimationToStandingAnimation : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.Idle);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
