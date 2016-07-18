using UnityEngine;
using System.Collections;
using System;

public class Olaf : BaseViking
{

    private enum ShieldPosition
    {
        FORWARD,
        UP
    }

    ShieldPosition m_ShieldPosition = ShieldPosition.FORWARD;

    public override void Action(InputState inputState)
    {
        if (inputState.CheckTriggered(InputAction.SPECIAL_ACTION1))
        {
            if (m_ShieldPosition == ShieldPosition.FORWARD)
            {
                m_ShieldPosition = ShieldPosition.UP;
            }
            else
            {
                m_ShieldPosition = ShieldPosition.FORWARD;
            }
        }
    }


    protected new void Update()
    {
        base.Update();
        m_Animator.SetBool("ShieldForward", m_ShieldPosition == ShieldPosition.FORWARD);
    }

    protected override void TopHit(Collider2D collider)
    {
        if (m_ShieldPosition == ShieldPosition.UP)
        {
            Debug.Log("Stopped something from hitting me from the top");
        }
    }

    protected override void FrontHit(Collider2D collider)
    {
        if (m_ShieldPosition == ShieldPosition.FORWARD)
        {
            Debug.Log("Stopped something from hitting me from the front");
        }
    }
}
