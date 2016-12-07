using UnityEngine;
using System;

public interface ICharacter
{

    //void Jump();
    void Attack();
    void ReceiveDamage(int damage);
    void Action(InputState action);
    void NoInput();
    State GetState();
    AnimationState GetAnimationState();

}

public class AnimationState
{
    private Animator m_Animator;
    public AnimationState(Animator animator)
    {
        m_Animator = animator;
    }

    public void SetAnimationTrigger(AnimationStates state)
    {
        //m_Animator.SetTrigger(Enum.GetName(typeof(AnimationState), state));
    }
}

public enum AnimationStates
{

    Idle,
    Walking,
    Action1,
    Action2,
    Falling,
    ClimbingUp,
    ClimbingDown,
    EndClimbingTop,
    EndClimbingBottom
}



public enum ClimbingDirections
{
    UP,
    DOWN
}


public class State
{
    private bool attacking = false;
    public bool Attacking
    {
        get
        {
            return attacking;
        }
        set
        {
            attacking = value;
        }
    }

    private int ladderBoundsCount = 0;
    public bool WithinLadderBounds
    {
        get
        {
            return ladderBoundsCount == 2;
        }
    }

    private bool canAttack = false;
    public bool CanAttack
    {
        get
        {
            return canAttack;
        }
        set
        {
            canAttack = value;
        }
    }

    private bool climbingEnabled = false;
    public bool CanClimb
    {
        get
        {
            return climbingEnabled;
        }
        set
        {
            climbingEnabled = value;
        }
    }

    private bool canMoveUp = false;
    public bool CanMoveUp
    {
        get
        {
            return canMoveUp;
        }
        set
        {
            canMoveUp = value;

        }
    }

    private bool climbing = false;
    public bool Climbing
    {
        get
        {
            return climbing;
        }
        set
        {
            climbing = value;
        }
    }

    private bool canMoveDown = false;
    public bool CanMoveDown
    {
        get
        {
            return canMoveDown;
        }
        set
        {
            canMoveDown = value;
        }
    }

    private bool canMoveHorizontally = true;
    public bool CanMoveHorizontally
    {
        get
        {
            return canMoveHorizontally;
        }
        set
        {
            canMoveHorizontally = value;
        }
    }

    private ClimbingDirections climbingDirection = ClimbingDirections.DOWN;
    public ClimbingDirections ClimbingDirection
    {
        get
        {
            return climbingDirection;
        }
        set
        {
            climbingDirection = value;
        }
    }

    public void Clear() { }

    public State Clone()
    {
        State newState = new State();

        return newState;
    }
}
