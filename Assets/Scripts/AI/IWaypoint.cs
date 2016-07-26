using UnityEngine;
public interface IWaypoint
{
    IWaypoint NextWaypoint(IWaypoint lastWaypoint);
    bool Reached(Transform walker);
    //IWaypoint PreviousWaypoint(IWaypoint lastWaypoint);
}
