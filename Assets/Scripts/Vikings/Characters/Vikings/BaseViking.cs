using UnityEngine;
using System.Collections;
using System;

public abstract class BaseViking : MonoBehaviour, ICharacter
{

    private enum FacingDirection
    {
        LEFT,
        RIGHT
    }

    public float m_MovementSpeed = 1.5f;
    public float m_MaxFallingDistance = 3f;

    public Generic2DBoxCollider m_GroundCollider;
    public Generic2DBoxCollider m_TopCollider;
    public Generic2DBoxCollider m_ForontCollider;

    protected Animator m_Animator;
    protected Transform m_Transform;
    protected Rigidbody2D m_RigidBody;

    protected Vector2 m_CurrentVelocityVector;
    protected float m_CurrentHorizontalSpeed = 0;
    protected float m_CurrentVerticalSpeed = 0;

    private float m_FallBeganTimestamp;

    bool m_LeftLadderTriggerReached = false;
    bool m_RightLadderTriggerReached = false;
    bool m_CanClimb = false;
    bool m_Climbing = false;
    bool m_Falling = true;

    FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    float m_FallingDistance = 0;

    Vector2 m_FallStartPosition = Vector2.zero;

    public void MoveHorizontaly(float direction)
    {
        // Rigidbody
        Vector2 vikingVelocity = m_RigidBody.velocity;
        m_CurrentHorizontalSpeed = Math.Abs(direction);
        vikingVelocity.x = direction * m_MovementSpeed;
        m_RigidBody.velocity = vikingVelocity;

        // Transform
        //Vector2 olafTranslate = new Vector2(speed, 0);
        //m_OlafTransform.Translate(olafTranslate);
    }

    public void MoveVertically(float direction)
    {
        Vector2 vikingVelocity = m_RigidBody.velocity;
        m_CurrentVerticalSpeed = Math.Abs(direction);
        vikingVelocity.y = direction * m_MovementSpeed;
        m_RigidBody.velocity = vikingVelocity;
    }

    #region ICharacter overrides

    public void NoInput()
    {
        m_CurrentHorizontalSpeed = 0;
        m_CurrentVerticalSpeed = 0;

        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = 0;
        if (m_CanClimb)
            currentVelocity.y = 0;
        m_RigidBody.velocity = currentVelocity;
    }

    public abstract void Action(InputState state);

    public void MoveLeft(float speed)
    {
        if (m_FacingDirection == FacingDirection.RIGHT)
        {
            ChangeFacingDirection();
            m_FacingDirection = FacingDirection.LEFT;
        }
        MoveHorizontaly(-speed);
    }

    public void MoveRight(float speed)
    {
        if (m_FacingDirection == FacingDirection.LEFT)
        {
            ChangeFacingDirection();
            m_FacingDirection = FacingDirection.RIGHT;
        }

        MoveHorizontaly(speed);
    }

    public void MoveUp(float speed)
    {
        if (!m_CanClimb)
            return;
        m_Climbing = true;
        MoveVertically(speed);
    }

    public void MoveDown(float speed)
    {
        if (!m_CanClimb)
            return;
        m_Climbing = true;
        MoveVertically(-speed);
    }

    public void Hit()
    {
        m_Animator.SetTrigger("Hit");
    }

    #endregion

    #region Collision Detection

    void Grounded(Collider2D collider)
    {
        m_Falling = false;
        m_FallBeganTimestamp = 0;
        m_FallStartPosition = Vector2.zero;
        m_FallingDistance = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "LadderLeftTrigger":
                // reached the ladder
                m_LeftLadderTriggerReached = true;
                break;
            case "LadderRightTrigger":
                m_RightLadderTriggerReached = true;
                break;
            case "LadderTrigger":
                // reached top/bottom
                // disable the climbing animation 

                break;
        }
        // mark climbable 
        m_CanClimb = true;
        // mark rigidbody as kinematic
        m_RigidBody.isKinematic = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "LadderLeftTrigger":
                // reached the ladder
                m_LeftLadderTriggerReached = false;
                break;
            case "LadderRightTrigger":
                m_RightLadderTriggerReached = false;
                break;
        }
    }

    void Falling(Collider2D collider)
    {
        m_Falling = true;
        m_FallBeganTimestamp = Time.realtimeSinceStartup;
        m_FallStartPosition = m_Transform.position;
    }

    protected abstract void TopHit(Collider2D collider);
    protected abstract void FrontHit(Collider2D collider);
    #endregion 

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Transform = gameObject.transform;
        m_RigidBody = GetComponent<Rigidbody2D>();

        m_GroundCollider.OnTriggerEnter = Grounded;
        m_GroundCollider.OnTriggerExit = Falling;
        m_TopCollider.OnTriggerEnter = TopHit;
        m_ForontCollider.OnTriggerEnter = FrontHit;
    }

    void ChangeFacingDirection()
    {
        Vector3 scale = m_Transform.localScale;
        scale.x *= -1;
        m_Transform.localScale = scale;
    }

    protected void Update()
    {
        if (m_LeftLadderTriggerReached && m_RightLadderTriggerReached)
        {
            m_RigidBody.isKinematic = true;
            m_CanClimb = true;
        }
        else
        {
            m_RigidBody.isKinematic = false;
            m_CanClimb = false;
        }
        SetAnimationsParameters();
    }

    void SetAnimationsParameters()
    {
        m_Animator.SetFloat("Speed", m_CurrentHorizontalSpeed);
        if (m_CanClimb)
        {
            m_Animator.SetBool("Climbing", m_Climbing);
        }
        else
        {
            m_Animator.SetBool("Climbing", false);
        }

        m_Animator.SetBool("Grounded", !m_Falling);

        if (m_FallingDistance >= m_MaxFallingDistance)
        {
            m_Animator.SetTrigger("Fall_Too_High");
        }
    }

    void FixedUpdate()
    {
        Vector2 currentVelocity = m_RigidBody.velocity;
        if (m_Falling)
        {
            m_FallingDistance = Vector2.Distance(m_FallStartPosition, m_Transform.position);

            //float fallingTime = m_FallBeganTimestamp - Time.realtimeSinceStartup;

            //currentVelocity.y = m_RigidBody.gravityScale * fallingTime * 8.81f;
        }
        else
        {
            currentVelocity.y = 0;
        }
        //m_RigidBody.velocity = currentVelocity;
    }


}
