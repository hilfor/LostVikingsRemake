﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RedDinosaur : BaseEnemy, IWalker, IFollower
{


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
    private IWaypoint m_NextWaypoint;

    private IBTNode m_Bt;

    private FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    private IPlayer m_PlayerToAttack = null;
    private List<IPlayer> m_PotentialPlayersList = new List<IPlayer>();

    private Transform m_Transform;

    private Rigidbody2D m_RigidBody;

    private State m_State;

    private IBTNode m_BehaviourTree = null;
    private IContext m_Context;

    public void Start()
    {
        //m_Animator = GetComponent<Animator>();

        m_Transform = transform;
        m_RigidBody = GetComponent<Rigidbody2D>();

        m_HitBoxCollider.OnTriggerEnter = PlayerEnteredAttackRange;
        m_FrontCollider.OnTriggerEnter = PlayerEnteredAttackRange;
        m_FrontCollider.OnTriggerExit = PlayerExitedAttackRange;

        m_NextWaypoint = m_StartWaypoint;

        m_BehaviourTree = GetNode();
        m_State = new State();
        m_Context = CreateClassContext();
    }

    public void Update()
    {
        m_BehaviourTree.Process(m_Context);
    }

    public IContext CreateClassContext()
    {
        IContext newContext = new Context();

        Type t = this.GetType();
        Type[] interfaces = t.GetInterfaces();
        foreach (Type ti in interfaces)
        {
            newContext.SetVariable(ti.Name, this);
        }

        return newContext;
    }

    public IBTNode GetNode()
    {
        Behavior behav = FindObjectOfType<Behavior>();
        return behav.GetTree(Behavior.BehaviorTypes.DragonBasic);
    }

    #region implemented stuff
    private void PlayerEnteredAttackRange(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            m_State.Attacking = true;
            IPlayer playerInRange = otherCollider.GetComponent<IPlayer>();
            if (m_PlayerToAttack == null)
            {
                m_PlayerToAttack = playerInRange;
            }
            else
            {
                if (!m_PotentialPlayersList.Contains(playerInRange))
                {
                    m_PotentialPlayersList.Add(playerInRange);
                }
            }
        }
    }

    private void PlayerExitedAttackRange(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            IPlayer playerExited = otherCollider.GetComponent<IPlayer>();
            if (m_PotentialPlayersList.Contains(playerExited))
            {
                m_PotentialPlayersList.Remove(playerExited);
            }
            else
            {
                if (m_PlayerToAttack == playerExited)
                {
                    m_PlayerToAttack = null;

                }
            }

            if (m_PotentialPlayersList.Count == 0 && m_PlayerToAttack == null)
            {
                m_State.Attacking = false;
            }
        }
    }

    public IWaypoint GetNextWaypoint()
    {
        return m_NextWaypoint.NextWaypoint(m_NextWaypoint);
    }



    public override State GetState()
    {
        return m_State;
    }

    public Vector2 GetWalkerPosition()
    {
        return m_Transform.position;
    }

    public float GetWalkerSpeed()
    {
        return m_Speed;
    }

    public Transform GetWalkerTransform()
    {
        return m_Transform;
    }

    public override bool IsCollidedWithPlayer()
    {
        return m_State.Attacking;
    }

    public void MoveDown(float speed)
    {
        throw new NotImplementedException();
    }

    public void MoveLeft(float speed)
    {
        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = -speed;
        m_RigidBody.velocity = currentVelocity;
    }

    public void MoveRight(float speed)
    {
        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = speed;
        m_RigidBody.velocity = currentVelocity;

    }

    public void MoveUp(float speed)
    {
        throw new NotImplementedException();
    }


    public override void ReceiveDamage(int damage)
    {
        m_Health -= damage;
    }

    public void SetNextWaypoint(IWaypoint waypoint)
    {
        m_NextWaypoint = waypoint;
    }

    public override void StopAttackPlayer()
    {
        m_State.Attacking = false;
    }
    #endregion

    public void ChangeDirection(FacingDirection newDirection)
    {
        m_FacingDirection = newDirection;
        Vector2 localScale = m_Transform.localScale;
        localScale.x *= -1;
        m_Transform.localScale = localScale;
    }

    public override AnimationState GetAnimationState()
    {
        throw new NotImplementedException();
    }

    public FacingDirection GetFacingDirection()
    {
        return m_FacingDirection;
    }

    public override void Attack()
    {
        // TODO: check a timer if should attack (not every frame)
        m_PlayerToAttack.ReceiveDamage(m_AttackDamage);
        throw new NotImplementedException();
    }

    public IWaypoint GetCurrentWaypoint()
    {
        return m_NextWaypoint;
    }

    public float GetWalkerCurrentSpeed()
    {
        return Math.Abs(m_RigidBody.velocity.magnitude);
    }

    public Vector2 GetMovementDirection()
    {
        return m_RigidBody.velocity;
    }

    public void FallDown(float speed)
    {
        throw new NotImplementedException();
    }

    public void FallDown()
    {
        throw new NotImplementedException();
    }

    public void StopFalling()
    {
        throw new NotImplementedException();
    }
}
