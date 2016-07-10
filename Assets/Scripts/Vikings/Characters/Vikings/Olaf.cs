﻿using UnityEngine;
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

    public override void Action(InputAction action)
    {
        if (action == InputAction.TRIGGER_SPECIAL_ACTION1)
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
        m_Animator.SetBool("ShieldForward", m_ShieldPosition == ShieldPosition.FORWARD);
        base.Update();
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
