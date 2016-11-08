using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RedDinosaur : MonoBehaviour, IEnemy, IWalker, IFollower
{

    //[SerializeField]
    //private Generic2DBoxCollider m_GroundCollider;
    [SerializeField]
    private Generic2DBoxCollider m_FrontCollider;
    [SerializeField]
    private Generic2DBoxCollider m_HitBoxCollider;
    [SerializeField]
    private Waypoint m_StartWaypoint;

    [SerializeField]
    private int m_Health = 1;

    [SerializeField]
    private float m_Speed = 1;

    [SerializeField]
    private int m_AttackDamage = 1;

    [SerializeField]
    private float m_TimeBetweenAttacks = 2f;

    private IWaypoint m_NextWaypoint;
    private Vector2 m_NextWaypointPosition;

    private Animator m_Animator;

    private bool m_AbleToMove = true;
    private bool m_Grounded = false;

    private FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    private ICharacter m_PlayerToAttack = null;
    private List<ICharacter> m_PotentialPlayersList = new List<ICharacter>();

    private Transform m_Transform;

    private Rigidbody2D m_RigidBody;

    private bool m_AttackStarted = false;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_HitBoxCollider.OnTriggerEnter = PlayerEnteredAttackRange;
        //m_GroundCollider.OnTriggerEnter = GroundCollidedCheck;
        //m_GroundCollider.OnTriggerExit = GroundLeftCheck;
        m_Transform = transform;
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_FrontCollider.OnTriggerEnter = PlayerEnteredAttackRange;
        m_FrontCollider.OnTriggerExit = PlayerExitedAttackRange;
        m_NextWaypoint = m_StartWaypoint;
        m_NextWaypointPosition = m_NextWaypoint.GetWaypointPosition();
    }


    void GroundCollidedCheck(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Ground")
        {
            m_Grounded = true;
        }
    }

    void GroundLeftCheck(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Ground")
        {
            m_Grounded = false;
        }
    }

    void PlayerEnteredAttackRange(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            ICharacter otherPlayer = otherCollider.GetComponent<ICharacter>();
            if (m_PotentialPlayersList.IndexOf(otherPlayer) == -1)
            {
                m_PotentialPlayersList.Add(otherCollider.GetComponent<ICharacter>());
            }
            if (!m_AttackStarted)
            {
                m_AttackStarted = true;
                StartCoroutine("AttackingEnemy");
            }
        }
    }

    IEnumerator AttackingEnemy()
    {

        m_AbleToMove = false;
        m_Animator.SetBool("Attacking", true);
        while (m_PotentialPlayersList.Count > 0)
        {
            m_PlayerToAttack = m_PotentialPlayersList[0];
            while (m_PlayerToAttack != null)
            {
                m_PlayerToAttack.ReceiveDamage(m_AttackDamage);
                yield return new WaitForSeconds(1);
            }
            m_PotentialPlayersList.RemoveAt(0);
        }
        m_Animator.SetBool("Attacking", false);
        m_AttackStarted = false;
        m_AbleToMove = true;

    }

    void PlayerExitedAttackRange(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            ICharacter exitedPlayer = otherCollider.GetComponent<ICharacter>();
            if (m_PlayerToAttack.Equals(exitedPlayer))
            {
                m_PlayerToAttack = null;
            }
            else
            {
                if (m_PotentialPlayersList.Count > 0)
                {
                    int playerIndex = m_PotentialPlayersList.FindIndex((ele) => ele.Equals(exitedPlayer));
                    m_PotentialPlayersList.RemoveAt(playerIndex);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (m_NextWaypoint.Reached(this))
        {
            m_NextWaypoint = m_NextWaypoint.NextWaypoint(m_NextWaypoint); // TODO: It sounds kinda funny, change this
            m_NextWaypointPosition = m_NextWaypoint.GetWaypointPosition();
            return;
        }


        // Transform 
        //Move(m_Speed);

        // RigidBody
        if (m_AbleToMove)
            Move(m_Speed);

    }


    private void Move(float speed)
    {
        //m_Transform.Translate()
        Vector2 myPosition = m_Transform.position;
        Vector2 direction = m_NextWaypointPosition - myPosition;
        direction.Normalize();

        if (direction.x > 0)
        {
            if (m_FacingDirection == FacingDirection.LEFT)
                ChangeDirection(FacingDirection.RIGHT);
            MoveRight(speed);
        }
        else if (direction.x < 0)
        {
            if (m_FacingDirection == FacingDirection.RIGHT)
                ChangeDirection(FacingDirection.LEFT);
            MoveLeft(speed);
        }

    }

    private void ChangeDirection(FacingDirection toDirection)
    {
        m_FacingDirection = toDirection;
        Vector2 localScale = m_Transform.localScale;
        localScale.x *= -1;
        m_Transform.localScale = localScale;
    }

    public void MoveRight(float speed)
    {
        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = speed;
        m_RigidBody.velocity = currentVelocity;
    }

    public void MoveLeft(float speed)
    {
        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = -speed;
        m_RigidBody.velocity = currentVelocity;
    }

    public void MoveUp(float speed)
    {
        throw new NotImplementedException();
    }

    public void MoveDown(float speed)
    {
        throw new NotImplementedException();
    }

    Vector2 IWalker.GetWalkerPosition()
    {
        return m_Transform.position;
    }
}
