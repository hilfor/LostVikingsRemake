using UnityEngine;
using System.Collections;
using System;

public class Olaf : MonoBehaviour, ICharacter
{

    private enum FacingDirection
    {
        LEFT,
        RIGHT
    }

    private enum ShieldPosition
    {
        FORWARD,
        UP
    }

    Animator m_Animator;

    bool m_Grounded;

    ShieldPosition m_ShieldPosition;
    FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    Transform m_OlafTransform;
    Rigidbody2D m_OlafRigidBody;

    public void Action(InputAction action)
    {
        throw new NotImplementedException();
    }

    public void Jump()
    {
        Debug.Log("Olaf is Jumping");
    }

    public void MoveLeft(float speed)
    {
        if (m_FacingDirection == FacingDirection.RIGHT)
        {
            ChangeFacingDirection();
            m_FacingDirection = FacingDirection.LEFT;
        }

        Vector2 olafVelocity = m_OlafRigidBody.velocity;
        olafVelocity.x = -speed;
        m_OlafRigidBody.velocity = olafVelocity;
        m_Animator.SetFloat("Speed", speed);
    }

    public void MoveRight(float speed)
    {
        if (m_FacingDirection == FacingDirection.LEFT)
        {
            ChangeFacingDirection();
            m_FacingDirection = FacingDirection.RIGHT;
        }
        Vector2 olafVelocity = m_OlafRigidBody.velocity;
        olafVelocity.x = speed;
        m_OlafRigidBody.velocity = olafVelocity;
        m_Animator.SetFloat("Speed", speed);
    }

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_OlafTransform = gameObject.transform;
        m_OlafRigidBody = GetComponent<Rigidbody2D>();
    }

    void ChangeFacingDirection()
    {
        Vector3 scale = m_OlafTransform.localScale;
        scale.x *= -1;
        m_OlafTransform.localScale = scale;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (m_OlafRigidBody.velocity != Vector2.zero)
        //{
        //    m_Animator.SetFloat("Speed", 1f);
        //}
        //else
        //{
        //    m_Animator.SetFloat("Speed", 0);
        //}
    }

    void FixedUpdate()
    {
        


    }
}
