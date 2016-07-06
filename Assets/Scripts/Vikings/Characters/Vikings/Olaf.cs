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
    FacingDirection m_FacingDirection;

    Transform m_OlafGraphic;
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
        if (m_FacingDirection == FacingDirection.RIGHT && m_ShieldPosition == ShieldPosition.UP)
        {
            ChangeFacingDirection();
        }

        m_OlafRigidBody.velocity = -Vector2.right;
    }

    public void MoveRight(float speed)
    {
        if (m_FacingDirection == FacingDirection.LEFT && m_ShieldPosition == ShieldPosition.UP)
        {
            ChangeFacingDirection();
        }
        m_OlafRigidBody.velocity = Vector2.right;
    }

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_OlafGraphic = gameObject.transform;
        m_OlafRigidBody = GetComponent<Rigidbody2D>();
    }

    void ChangeFacingDirection()
    {
        Vector3 scale = m_OlafGraphic.localScale;
        scale.x *= -1;
        m_OlafGraphic.localScale = scale;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (m_OlafRigidBody.velocity != Vector2.zero)
        {
            m_Animator.SetFloat("Speed", 1f);
        }
        else
        {
            m_Animator.SetFloat("Speed", 0);
        }


    }
}
