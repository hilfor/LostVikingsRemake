public interface ICharacter
{
    void MoveRight(float speed);
    void MoveLeft(float speed);
    //void Jump();
    void Hit();
    void Action(InputAction action);
    void NoInput();
}
