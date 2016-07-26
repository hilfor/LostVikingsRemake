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

    public bool Reached(Transform walker)
    {
        throw new NotImplementedException();
    }

    //public IWaypoint PreviousWaypoint(IWaypoint lastWaypoint)
    //{

    //}
}
