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
                m_CurrentHorizontalSpeed = m_SprintSpeed;
            m_ActivateSprint = true;
        }
        else
        {
            if (m_ActivateSprint)
                m_CurrentHorizontalSpeed = m_MovementSpeed;
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

    public override void ReceiveDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public override bool ReachedTopLadder()
    {
        throw new NotImplementedException();
    }

    public override bool ReachedBottomLadder()
    {
        throw new NotImplementedException();
    }

    public override void ExecuteAction1()
    {
        throw new NotImplementedException();
    }

    public override void ExecuteAction2()
    {
        throw new NotImplementedException();
    }

    public override InputState GetInputState()
    {
        throw new NotImplementedException();
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }

    public override State GetState()
    {
        throw new NotImplementedException();
    }

    public override AnimationState GetAnimationState()
    {
        throw new NotImplementedException();
    }

    public override Transform GetWalkerTransform()
    {
        throw new NotImplementedException();
    }

    public override FacingDirection GetFacingDirection()
    {
        throw new NotImplementedException();
    }

    public override float GetWalkerSpeed()
    {
        throw new NotImplementedException();
    }

    public override void ChangeDirection(FacingDirection newDirection)
    {
        throw new NotImplementedException();
    }
}
