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
    private bool attacking;
    public bool Attacking
    {
        get;
        set;
    }

    //private bool arrivedNextWaypoint;
    //public bool ArrivedAtNextWaypoint
    //{
    //    set;
    //    get;
    //}
}
