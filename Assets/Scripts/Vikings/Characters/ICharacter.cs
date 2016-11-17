using UnityEngine;
using System;

public interface ICharacter
{

    //void Jump();
    void Hit();
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
        m_Animator.SetTrigger(Enum.GetName(typeof(AnimationState), state));
    }
}

public enum AnimationStates
{
    EndClimbingTop,
    EndClimbingBottom
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

    public State Clone()
    {
        State newState = new State();

        return newState;
    }
}
