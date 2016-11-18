public class SetAnimationToFinishClimbingBottom: IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetAnimationState().SetAnimationTrigger(AnimationStates.EndClimbingBottom);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}