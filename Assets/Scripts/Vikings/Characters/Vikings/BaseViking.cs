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
    protected Generic2DBoxCollider m_ForontCollider;

    [SerializeField]
    protected int m_Health = 1;

    protected Animator m_Animator;
    protected Transform m_Transform;
    protected Rigidbody2D m_RigidBody;

    protected Vector2 m_CurrentVelocityVector;
    protected float m_CurrentHorizontalSpeed = 0;
    protected float m_CurrentVerticalSpeed = 0;

    private float m_FallBeganTimestamp;

    bool m_CanClimbUp = false;
    bool m_CanClimbDown = false;


    bool m_LadderReached = false;
    bool m_LadderLeftTriggerReached = false;
    bool m_LadderRightTriggerReached = false;

    bool m_Falling = false;

    FacingDirection m_FacingDirection = FacingDirection.RIGHT;

    float m_FallingDistance = 0;

    Vector2 m_FallStartPosition = Vector2.zero;



    private bool m_LadderTopReached;
    private bool m_LadderBottomReached;

    public bool ReachedTopLadder()
    {
        throw new NotImplementedException();
    }

    public bool ReachedBottomLadder()
    {
        throw new NotImplementedException();
    }

    public abstract void ExecuteAction1();

    public abstract void ExecuteAction2();

    public InputState GetInputState()
    {
        throw new NotImplementedException();
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }

    public void ReceiveDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public abstract void Action(InputState action);

    public void NoInput()
    {
        throw new NotImplementedException();
    }

    public State GetState()
    {
        throw new NotImplementedException();
    }

    public AnimationState GetAnimationState()
    {
        throw new NotImplementedException();
    }

    public Vector2 GetWalkerPosition()
    {
        throw new NotImplementedException();
    }

    public Transform GetWalkerTransform()
    {
        throw new NotImplementedException();
    }

    public FacingDirection GetFacingDirection()
    {
        throw new NotImplementedException();
    }

    public abstract float GetWalkerSpeed();

    public void ChangeDirection(FacingDirection newDirection)
    {
        throw new NotImplementedException();
    }

    public void MoveRight(float speed)
    {
        throw new NotImplementedException();
    }

    public void MoveLeft(float speed)
    {
        throw new NotImplementedException();
    }

    public void MoveUp(float speed)
    {
        throw new NotImplementedException();
    }

    public void MoveDown(float speed)
    {
        throw new NotImplementedException();
    }

    //public void MoveHorizontaly(float direction)
    //{
    //    if (!CheckHorizontalMovementEnabled())
    //        return;
    //    Vector2 vikingVelocity = m_RigidBody.velocity;
    //    m_CurrentHorizontalSpeed = Math.Abs(direction);
    //    vikingVelocity.x = direction * m_MovementSpeed;
    //    m_RigidBody.velocity = vikingVelocity;
    //}

    //public void MoveVertically(float direction)
    //{
    //    Vector2 vikingVelocity = m_RigidBody.velocity;
    //    m_CurrentVerticalSpeed = Math.Abs(direction);
    //    vikingVelocity.y = direction * m_MovementSpeed;
    //    m_RigidBody.velocity = vikingVelocity;
    //}

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

    //public void MoveLeft(float speed)
    //{
    //    if (m_FacingDirection == FacingDirection.RIGHT)
    //    {
    //        ChangeFacingDirection();
    //        m_FacingDirection = FacingDirection.LEFT;
    //    }
    //    MoveHorizontaly(-speed);
    //}

    //public void MoveRight(float speed)
    //{
    //    if (m_FacingDirection == FacingDirection.LEFT)
    //    {
    //        ChangeFacingDirection();
    //        m_FacingDirection = FacingDirection.RIGHT;
    //    }

    //    MoveHorizontaly(speed);
    //}

    //private bool CheckHorizontalMovementEnabled()
    //{
    //    return true;
    //}

    //public void MoveUp(float speed)
    //{
    //    if (m_CanClimbUp)
    //    {
    //        Debug.Log("Climbing up");
    //        MoveVertically(speed);
    //    }
    //}

    //public void MoveDown(float speed)
    //{
    //    if (m_CanClimbDown)
    //    {
    //        Debug.Log("Climbing down");
    //        MoveVertically(-speed);
    //    }
    //}

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
    //#region abstract functions
    //protected abstract void TopHit(Collider2D collider);
    //protected abstract void FrontHit(Collider2D collider);
    //#endregion

    //#endregion

    //void Awake()
    //{
    //    m_Animator = GetComponent<Animator>();
    //    m_Transform = gameObject.transform;
    //    m_RigidBody = GetComponent<Rigidbody2D>();

    //    m_GroundCollider.OnTriggerEnter = Grounded;
    //    m_GroundCollider.OnTriggerExit = Falling;
    //    m_TopCollider.OnTriggerEnter = TopHit;
    //    m_ForontCollider.OnTriggerEnter = FrontHit;
    //}

    //void ChangeFacingDirection()
    //{
    //    Vector3 scale = m_Transform.localScale;
    //    scale.x *= -1;
    //    m_Transform.localScale = scale;
    //}

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

    //public abstract bool ReachedTopLadder();
    //public abstract bool ReachedBottomLadder();
    //public abstract void ExecuteAction1();
    //public abstract void ExecuteAction2();
    //public abstract InputState GetInputState();
    //public abstract void Attack();
    //public abstract State GetState();
    //public abstract AnimationState GetAnimationState();
    //public abstract Transform GetWalkerTransform();
    //public abstract FacingDirection GetFacingDirection();
    //public abstract float GetWalkerSpeed();
    //public abstract void ChangeDirection(FacingDirection newDirection);
}
