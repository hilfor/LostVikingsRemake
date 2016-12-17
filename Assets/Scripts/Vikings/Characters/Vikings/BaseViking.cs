using UnityEngine;
using System.Collections;
using System;

public abstract class BaseViking : MonoBehaviour, IPlayer, IWalker
{

    [SerializeField]
    protected float m_MovementSpeed = 1.5f;
    [SerializeField]
    protected float m_MaxFallingDistance = 3f;

    [SerializeField]
    protected Generic2DBoxCollider m_GroundCollider;
    [SerializeField]
    protected Generic2DBoxCollider m_TopCollider;
    [SerializeField]
    protected Generic2DBoxCollider m_FrontCollider;
    [SerializeField]
    protected Generic2DBoxCollider m_SingleCollider;

    [SerializeField]
    protected int m_Health = 1;

    protected Animator m_Animator;
    protected Transform m_Transform;
    protected Rigidbody2D m_RigidBody;

    InputState m_InputState;

    private float m_FallBeganTimestamp;

    bool m_CanClimbUp = false;
    bool m_CanClimbDown = false;

    bool m_LadderLeftTriggerReached = false;
    bool m_LadderRightTriggerReached = false;

    FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    private bool m_LadderTopReached = false;
    private bool m_LadderBottomReached;

    private State m_State;

    private IBTNode m_BehaviourTree;
    private IContext m_Context;

    public abstract void ExecuteAction1();
    public abstract void ExecuteAction2();
    public abstract void Action(InputState action);
    public abstract void Attack();

    public AnimationState m_AnimationState;
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Transform = gameObject.transform;
        m_RigidBody = GetComponent<Rigidbody2D>();

        m_State = new State();

        m_SingleCollider.OnTriggerEnter = EnteredCollision;
        m_SingleCollider.OnTriggerExit = ExitCollision;

        m_Context = CreateClassContext();
        m_BehaviourTree = GetNode();
        m_AnimationState = new AnimationState(m_Animator);
        m_InputState = new InputState();
    }

    public void SetInputState(InputState inputState)
    {
        m_InputState = inputState;
    }

    public void Update()
    {
        m_BehaviourTree.Process(m_Context);
    }

    public IBTNode GetNode()
    {
        Behavior behav = FindObjectOfType<Behavior>();
        return behav.GetTree(Behavior.BehaviorTypes.PlayerBasic);
    }
    public AnimationState GetAnimationState()
    {
        return m_AnimationState;
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

    public float GetWalkerSpeed()
    {
        return m_MovementSpeed;
    }

    public virtual void EnteredCollision(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "LadderLeft":
                m_LadderLeftTriggerReached = true;
                break;
            case "LadderRight":
                m_LadderRightTriggerReached = true;
                break;
            case "LadderTop":
                m_LadderTopReached = true;
                break;
            case "LadderBottom":
                m_LadderBottomReached = true;
                break;

        }

        if (m_LadderLeftTriggerReached && m_LadderRightTriggerReached)
        {
            m_State.CanClimb = true;
            if (m_LadderTopReached)
            {
                m_State.CanMoveDown = true;
                m_State.CanMoveUp = false;
            }

            if (m_LadderBottomReached)
            {
                m_State.CanMoveDown = false;
                m_State.CanMoveUp = true;
            }
        }


    }

    public virtual void ExitCollision(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "LadderLeft":
                m_LadderLeftTriggerReached = false;
                break;
            case "LadderRight":
                m_LadderRightTriggerReached = false;
                break;
            case "LadderTop":
                m_LadderTopReached = false;
                break;
            case "LadderBottom":
                m_LadderBottomReached = false;
                break;

        }

        if (m_LadderTopReached == false && (m_LadderLeftTriggerReached && m_LadderRightTriggerReached))
        {
            m_State.CanMoveUp = true;
        }

        if (m_LadderBottomReached == false && (m_LadderLeftTriggerReached && m_LadderRightTriggerReached))
        {
            m_State.CanMoveDown = true;
        }

        if (!m_LadderLeftTriggerReached || !m_LadderRightTriggerReached)
        {
            m_State.CanClimb = false;
            m_State.CanMoveDown = false;
            m_State.CanMoveDown = false;
        }
    }

    public bool ReachedTopLadder()
    {
        return m_LadderTopReached;
    }

    public bool ReachedBottomLadder()
    {
        return m_LadderBottomReached;
    }

    public InputState GetInputState()
    {
        return m_InputState;
    }

    public abstract void ReceiveDamage(int damage);

    public void NoInput()
    {
        Vector2 currentVelocity = m_RigidBody.velocity;
        currentVelocity.x = 0;
        if (m_CanClimbUp || m_CanClimbDown)
            currentVelocity.y = 0;
        m_RigidBody.velocity = currentVelocity;
    }

    public State GetState()
    {
        return m_State;
    }

    public Vector2 GetWalkerPosition()
    {
        return m_Transform.position;
    }

    public Transform GetWalkerTransform()
    {
        return m_Transform;
    }

    public FacingDirection GetFacingDirection()
    {
        return m_FacingDirection;
    }

    public void MoveLeft(float speed)
    {
        MoveHorizontaly(-speed);
    }

    public void MoveRight(float speed)
    {
        MoveHorizontaly(speed);
    }

    public void MoveUp(float speed)
    {
        if (m_CanClimbUp)
        {
            Debug.Log("Climbing up");
            MoveVertically(speed);
        }
    }

    public void MoveDown(float speed)
    {
        if (m_CanClimbDown)
        {
            Debug.Log("Climbing down");
            MoveVertically(-speed);
        }
    }

    public void MoveHorizontaly(float direction)
    {
        Vector2 vikingVelocity = m_RigidBody.velocity;
        vikingVelocity.x = direction * m_MovementSpeed;
        m_RigidBody.velocity = vikingVelocity;
    }

    public void MoveVertically(float direction)
    {
        Vector2 vikingVelocity = m_RigidBody.velocity;
        vikingVelocity.y = direction * m_MovementSpeed;
        m_RigidBody.velocity = vikingVelocity;
    }


    public void ChangeDirection(FacingDirection newDirection)
    {
        if (newDirection == FacingDirection.LEFT)
        {
            newDirection = FacingDirection.RIGHT;
        }
        else
        {
            newDirection = FacingDirection.LEFT;
        }

        Vector3 scale = m_Transform.localScale;
        scale.x *= -1;
        m_Transform.localScale = scale;
    }

    public float GetWalkerCurrentSpeed()
    {
        return Math.Abs(m_RigidBody.velocity.magnitude);
    }

    public Vector2 GetMovementDirection()
    {
        return m_RigidBody.velocity;
    }

    public void FallDown()
    {
        //MoveVertically(-speed);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void StopFalling()
    {
        Vector2 vikingVelocity = m_RigidBody.velocity;
        vikingVelocity.y = 0;
        m_RigidBody.velocity = vikingVelocity;
    }


}
