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
    protected int m_Health = 1;

    protected Animator m_Animator;
    protected Transform m_Transform;
    protected Rigidbody2D m_RigidBody;

    InputState m_InputState;

    Vector2 m_CurrentVelocityVector;
    float m_CurrentHorizontalSpeed = 0;
    float m_CurrentVerticalSpeed = 0;

    private float m_FallBeganTimestamp;

    bool m_CanClimbUp = false;
    bool m_CanClimbDown = false;


    //bool m_LadderReached = false;
    bool m_LadderLeftTriggerReached = false;
    bool m_LadderRightTriggerReached = false;

    int m_LadderWallsCount = 0;

    bool m_Falling = false;

    FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    float m_FallingDistance = 0;

    Vector2 m_FallStartPosition = Vector2.zero;

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

        m_GroundCollider.OnTriggerEnter = GroundHit;
        m_GroundCollider.OnTriggerExit = GroundExit;
        m_TopCollider.OnTriggerEnter = TopReached;
        m_TopCollider.OnTriggerExit = TopExit;
        m_FrontCollider.OnTriggerEnter = FrontHit;
        m_FrontCollider.OnTriggerExit = FrontExit;
        m_Context = CreateClassContext();
        m_BehaviourTree = GetNode();
        m_AnimationState = new AnimationState(m_Animator);
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

        //newContext.SetVariable("ICharacter", this);

        return newContext;
    }

    public float GetWalkerSpeed()
    {
        return m_MovementSpeed;
    }

    public virtual void FrontHit(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "LadderLeft":
                m_LadderLeftTriggerReached = true;
                break;
            case "LadderRight":
                m_LadderRightTriggerReached = true;
                break;
        }
    }

    public virtual void FrontExit(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "LadderLeft":
                m_LadderLeftTriggerReached = false;
                break;
            case "LadderRight":
                m_LadderRightTriggerReached = false;
                break;
        }
    }

    public virtual void TopReached(Collider2D otherCollider)
    {
        if (otherCollider.tag == "LadderTop")
        {
            m_LadderTopReached = true;
            m_State.CanMoveDown = true;
        }
    }

    public void TopExit(Collider2D otherCollider)
    {
        if (otherCollider.tag == "LadderTop")
        {
            m_LadderTopReached = false;
        }
    }

    public bool ReachedTopLadder()
    {
        return m_LadderTopReached;
    }

    public void GroundHit(Collider2D otherCollider)
    {
        if (otherCollider.tag == "LadderBottom")
        {
            m_LadderBottomReached = true;
        }
    }

    public void GroundExit(Collider2D otherCollider)
    {
        if (otherCollider.tag == "LadderBottom")
        {
            m_LadderBottomReached = false;
        }
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
        //throw new NotImplementedException();
    }

    public State GetState()
    {
        return m_State;
    }

    public Vector2 GetWalkerPosition()
    {
        throw new NotImplementedException();
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
        m_CurrentHorizontalSpeed = Math.Abs(direction);
        vikingVelocity.x = direction * m_MovementSpeed;
        m_RigidBody.velocity = vikingVelocity;
    }

    public void MoveVertically(float direction)
    {
        Vector2 vikingVelocity = m_RigidBody.velocity;
        m_CurrentVerticalSpeed = Math.Abs(direction);
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


    #region commented out

    //#region ICharacter overrides

    //public void NoInput()
    //{
    //    m_CurrentHorizontalSpeed = 0;
    //    m_CurrentVerticalSpeed = 0;

    //    Vector2 currentVelocity = m_RigidBody.velocity;
    //    currentVelocity.x = 0;
    //    if (m_CanClimbUp || m_CanClimbDown)
    //        currentVelocity.y = 0;
    //    m_RigidBody.velocity = currentVelocity;
    //}

    //public abstract void Action(InputState state);


    //public void Hit()
    //{
    //    m_Animator.SetTrigger("Hit");
    //}

    //#endregion

    //#region Collision Detection

    //void Grounded(Collider2D collider)
    //{
    //    m_Falling = false;
    //    m_FallBeganTimestamp = 0;
    //    m_FallStartPosition = Vector2.zero;
    //    m_FallingDistance = 0;
    //}

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    switch (collision.tag)
    //    {
    //        case "Ladder":
    //            m_LadderReached = true;
    //            break;
    //        case "LadderLeftTrigger":
    //            if (m_LadderReached)
    //                m_LadderLeftTriggerReached = true;
    //            break;
    //        case "LadderRightTrigger":
    //            if (m_LadderReached)
    //                m_LadderRightTriggerReached = true;
    //            break;
    //        case "LadderTopTrigger":
    //            if (m_LadderReached)
    //            {
    //                m_LadderTopReached = true;
    //                ResetVerticalVelocity();
    //            }
    //            break;
    //        case "LadderBottomTrigger":
    //            if (m_LadderReached)
    //            {
    //                m_LadderBottomReached = true;
    //                ResetVerticalVelocity();
    //            }
    //            break;
    //    }
    //}

    //private void ResetVerticalVelocity()
    //{
    //    Vector2 vel = m_RigidBody.velocity;
    //    vel.y = 0;
    //    m_RigidBody.velocity = vel;
    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    switch (collision.tag)
    //    {
    //        case "Ladder":
    //            ResetLadderTriggers();
    //            break;
    //        case "LadderLeftTrigger":
    //            m_LadderLeftTriggerReached = false;
    //            break;
    //        case "LadderRightTrigger":
    //            m_LadderRightTriggerReached = false;
    //            break;
    //        case "LadderTopTrigger":
    //            m_LadderTopReached = false;
    //            break;
    //        case "LadderBottomTrigger":
    //            m_LadderBottomReached = false;
    //            break;
    //    }
    //}

    //private void ResetLadderTriggers()
    //{
    //    Debug.LogError("ResetLadderTriggers is not fully implemented Yet!");
    //    m_RigidBody.isKinematic = false;

    //    m_LadderReached = false;
    //    m_LadderBottomReached = false;
    //    m_LadderTopReached = false;
    //    m_LadderRightTriggerReached = false;
    //    m_LadderLeftTriggerReached = false;
    //    m_CanClimbDown = false;
    //    m_CanClimbUp = false;
    //}

    //void Falling(Collider2D collider)
    //{
    //    if (collider.tag == "Ground")
    //        return;
    //    m_Falling = true;
    //    m_FallBeganTimestamp = Time.realtimeSinceStartup;
    //    m_FallStartPosition = m_Transform.position;
    //}

    //protected abstract void TopHit(Collider2D collider);
    //protected abstract void FrontHit(Collider2D collider);





    //protected void Update()
    //{
    //    CheckLadderClimbingState();
    //    SetAnimationsParameters();
    //}

    //void CheckLadderClimbingState()
    //{
    //    if (!m_LadderReached && !(m_LadderLeftTriggerReached && m_LadderRightTriggerReached))
    //        return;

    //    m_RigidBody.isKinematic = true;

    //    if (m_LadderTopReached)
    //    {
    //        m_CanClimbDown = true;
    //        m_CanClimbUp = false;
    //    }
    //    else if (m_LadderBottomReached)
    //    {
    //        m_CanClimbDown = false;
    //        m_CanClimbUp = true;
    //    }
    //    else
    //    {
    //        m_CanClimbDown = true;
    //        m_CanClimbUp = true;
    //    }
    //}

    //void SetAnimationsParameters()
    //{
    //    //Vector2 currentVelocity = m_RigidBody.velocity;
    //    //if (m_CanClimbUp || m_CanClimbDown)
    //    //{
    //    //    m_Animator.SetBool("Climbing", true);
    //    //    if (currentVelocity.y > 0)
    //    //    {
    //    //        Debug.Log("Climbing up animation");
    //    //        m_Animator.StartPlayback();

    //    //    }
    //    //    else if (currentVelocity.y < 0)
    //    //    {
    //    //        Debug.Log("Climbing down animation");
    //    //        m_Animator.StartPlayback();
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.Log("Stopping ");

    //    //        m_Animator.StopPlayback();
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    m_Animator.SetBool("Climbing", false);

    //    //}

    //    m_Animator.SetFloat("Speed", m_CurrentHorizontalSpeed);

    //    m_Animator.SetBool("Grounded", !m_Falling);

    //    if (m_FallingDistance >= m_MaxFallingDistance)
    //    {
    //        m_Animator.SetTrigger("Fall_Too_High");
    //    }
    //}

    //void FixedUpdate()
    //{
    //    Vector2 currentVelocity = m_RigidBody.velocity;

    //    if (m_Falling)
    //    {
    //        m_FallingDistance = Vector2.Distance(m_FallStartPosition, m_Transform.position);
    //    }
    //    else
    //    {
    //        currentVelocity.y = 0;
    //    }
    //}

    //public abstract void ReceiveDamage(int damage);

    //Vector2 IWalker.GetWalkerPosition()
    //{
    //    return m_Transform.position;
    //}
    #endregion

}
