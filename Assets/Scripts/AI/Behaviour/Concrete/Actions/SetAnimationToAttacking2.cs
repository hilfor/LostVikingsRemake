using UnityEngine;
using System;

public class SetAnimationToAttacking2 : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.Action2);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
