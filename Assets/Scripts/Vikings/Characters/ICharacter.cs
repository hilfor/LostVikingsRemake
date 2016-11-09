public interface ICharacter
{

    //void Jump();
    void Hit();
    void ReceiveDamage(int damage);
    void Action(InputState action);
    void NoInput();
    State GetState();


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


    //private bool arrivedNextWaypoint;
    //public bool ArrivedAtNextWaypoint
    //{
    //    set;
    //    get;
    //}

    public State Clone()
    {
        State newState = new State();

        return newState;
    }
}
