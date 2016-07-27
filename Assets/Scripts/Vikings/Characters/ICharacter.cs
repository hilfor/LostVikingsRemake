public interface ICharacter
{

    //void Jump();
    void Hit();
    void ReceiveDamage(int damage);
    void Action(InputState action);
    void NoInput();
}
