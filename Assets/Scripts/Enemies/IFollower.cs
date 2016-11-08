using UnityEngine;
using System.Collections;

public interface IFollower
{

    void SetNextWaypoint(IWaypoint waypoint);
    IWaypoint GetNextWaypoint();
}
