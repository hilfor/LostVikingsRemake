using UnityEngine;

public class WalkToNextWaypoint : IBTAction
{
    public bool Act(IContext context)
    {
        IWalker walker = (IWalker)context.GetVariable("IWalker");
        IFollower follower = (IFollower)context.GetVariable("IFollower");
        FacingDirection facingDirection = walker.GetFacingDirection();

        float maxWalkingSpeed = walker.GetWalkerSpeed();
            //= (float)context.GetVariable("maxWalkingSpeed");

        Vector2 myPosition = walker.GetWalkerTransform().position;
        Vector2 direction = follower.GetNextWaypoint().GetWaypointPosition() - myPosition;
        direction.Normalize();

        if (direction.x > 0)
        {
            if (facingDirection == FacingDirection.LEFT)
                walker.ChangeDirection(FacingDirection.RIGHT);
            walker.MoveRight(maxWalkingSpeed);
        }
        else if (direction.x < 0)
        {
            if (facingDirection == FacingDirection.RIGHT)
                walker.ChangeDirection(FacingDirection.LEFT);
            walker.MoveLeft(maxWalkingSpeed);
        }
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}