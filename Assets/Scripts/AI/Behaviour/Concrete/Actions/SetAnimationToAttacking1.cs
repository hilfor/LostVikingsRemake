using UnityEngine;
using System.Collections;
using System;

public class SetAnimationToAttacking1 : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.Action1);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
