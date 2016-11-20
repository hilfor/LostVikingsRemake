public class SetAnimationToFinishClimbingTop : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.EndClimbingTop);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}