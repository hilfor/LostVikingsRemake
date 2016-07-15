using UnityEngine;
using System.Collections;
using System;

public class Eric : BaseViking
{

    public float m_SprintSpeed = 5f;
    public float m_JumpForce = 5f;

    bool m_ActivateSprint = false;


    public override void Action(InputState inputState)
    {
        if (inputState.CheckPressed(InputAction.SPECIAL_ACTION1))
        {
            if (!m_ActivateSprint)
                m_CurrentSpeed = m_SprintSpeed;
            m_ActivateSprint = true;
        }
        else
        {
            if (m_ActivateSprint)
                m_CurrentSpeed = m_MovementSpeed;
            m_ActivateSprint = false;
        }
        if (inputState.CheckTriggered(InputAction.SPECIAL_ACTION2))
        {
            Vector2 currentVelocity = m_RigidBody.velocity;
            currentVelocity.y = m_JumpForce;
            m_RigidBody.velocity = currentVelocity;
        }
    }



    protected override void FrontHit(Collider2D collider)
    {
        base.Hit();
    }

    protected override void TopHit(Collider2D collider)
    {
        base.Hit();
    }


}
