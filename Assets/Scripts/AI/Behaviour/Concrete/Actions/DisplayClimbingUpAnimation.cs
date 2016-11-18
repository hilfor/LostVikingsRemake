using UnityEngine;
using System.Collections;

public class DisplayClimbingUpAnimation : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.ClimbingUp);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
