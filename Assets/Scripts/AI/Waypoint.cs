using UnityEngine;
using System.Collections;
using System;

public class Waypoint : MonoBehaviour, IWaypoint
{
    [SerializeField]
    private Waypoint m_RightWaypoint;
    [SerializeField]
    private Waypoint m_LeftWaypoint;
    [SerializeField]
    private bool M_Loop = false;
    [SerializeField]
    private float m_WaypointReachedRadius = 0f;


    private Transform m_Transform;

    void Start()
    {
        m_Transform = transform;
    }

    public IWaypoint NextWaypoint(IWaypoint lastWaypoint)
    {
        if (M_Loop)
        {
            return (m_RightWaypoint == null) ? m_LeftWaypoint : m_RightWaypoint;
        }
        else
        {
            if (lastWaypoint.Equals(m_RightWaypoint))
                return m_LeftWaypoint;
            else
                return m_RightWaypoint;
        }
    }

    public Vector2 GetWaypointPosition()
    {
        return m_Transform.position;
    }

    public bool Reached(IWalker walker)
    {
        if (Vector2.Distance(walker.GetWalkerPosition(), m_Transform.position) <= m_WaypointReachedRadius)
            return true;
        return false;
    }

}
