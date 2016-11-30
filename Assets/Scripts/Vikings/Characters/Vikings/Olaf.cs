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


    //protected void Update()
    //{
        //m_Animator.SetBool("ShieldForward", m_ShieldPosition == ShieldPosition.FORWARD);
    //}

    

    public override void TopReached(Collider2D collider)
    {
        base.TopReached(collider);
        if (m_ShieldPosition == ShieldPosition.UP)
        {
            Debug.Log("Stopped something from hitting me from the top");
        }
        
    }

    public override void FrontHit(Collider2D collider)
    {
        base.FrontHit(collider);
        if (m_ShieldPosition == ShieldPosition.FORWARD)
        {
            Debug.Log("Something hit me from the front!");
        }
    }

    public override void ReceiveDamage(int damage)
    {
        if (m_ShieldPosition != ShieldPosition.FORWARD)
        {
            if (m_Health > 0)
            {
                Debug.Log("Being attacked by something !!! ");
                m_Health--;
            }

        }
    }

    public override void ExecuteAction1()
    {
        throw new NotImplementedException();
    }

    public override void ExecuteAction2()
    {
        throw new NotImplementedException();
    }

    

    public override void Attack()
    {
        throw new NotImplementedException();
    }

    
}
