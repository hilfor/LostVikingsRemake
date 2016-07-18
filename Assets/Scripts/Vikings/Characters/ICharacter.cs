public interface ICharacter
{
    void MoveRight(float speed);
    void MoveLeft(float speed);
    void MoveUp(float speed);
    void MoveDown(float speed);
    //void Jump();
    void Hit();
    void Action(InputState action);
    void NoInput();
}
