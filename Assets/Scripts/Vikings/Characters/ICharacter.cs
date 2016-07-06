public interface ICharacter
{
    void MoveRight(float speed);
    void MoveLeft(float speed);
    void Jump();
    void Action(InputAction action);
}
