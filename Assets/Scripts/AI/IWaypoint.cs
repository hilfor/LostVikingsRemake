using UnityEngine;
public interface IWaypoint
{
    IWaypoint NextWaypoint(IWaypoint lastWaypoint);
    Vector2 GetWaypointPosition();
    bool Reached(IWalker walker);
    //IWaypoint PreviousWaypoint(IWaypoint lastWaypoint);
}
