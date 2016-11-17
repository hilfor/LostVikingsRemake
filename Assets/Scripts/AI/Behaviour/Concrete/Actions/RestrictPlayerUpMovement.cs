public class RestrictPlayerUpMovement : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetState().CanMoveUp = false;
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}