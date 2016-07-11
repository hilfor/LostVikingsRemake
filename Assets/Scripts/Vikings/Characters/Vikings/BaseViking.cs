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
    protected float m_CurrentSpeed = 0;

    bool m_Climbing = false;
    bool m_Falling = false;

    FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    float m_FallingDistance = 0;

    Vector2 m_FallStartPosition = Vector2.zero;

    public void Move(float direction)
    {
        // Rigidbody
        Vector2 vikingVelocity = m_RigidBody.velocity;
        m_CurrentSpeed = Math.Abs(direction);
        vikingVelocity.x = direction * m_MovementSpeed;
        m_RigidBody.velocity = vikingVelocity;

        // Transform
        //Vector2 olafTranslate = new Vector2(speed, 0);
        //m_OlafTransform.Translate(olafTranslate);
    }

    #region ICharacter overrides

    public void NoInput()
    {
        m_CurrentSpeed = 0;

        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = 0;
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
        Move(-speed);
    }

    public void MoveRight(float speed)
    {
        if (m_FacingDirection == FacingDirection.LEFT)
        {
            ChangeFacingDirection();
            m_FacingDirection = FacingDirection.RIGHT;
        }

        Move(speed);
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
    }

    void Falling(Collider2D collider)
    {
        m_Falling = true;
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
        m_Animator.SetFloat("Speed", m_CurrentSpeed);
        m_Animator.SetBool("Climbing", m_Climbing);
        m_Animator.SetBool("Grounded", !m_Falling);
        m_Animator.SetBool("Falling", m_Falling);

        if (m_FallingDistance >= m_MaxFallingDistance)
        {
            Debug.Log(m_FallingDistance);
            m_Animator.SetTrigger("Fall_Too_High");
        }
    }

    void FixedUpdate()
    {
        if (m_Falling)
        {
            m_FallingDistance = Vector2.Distance(m_FallStartPosition, m_Transform.position);
        }
        else
        {
            m_FallingDistance = 0;
            m_FallStartPosition = Vector2.zero;
        }
    }

}
