using UnityEngine;
using System.Collections;

public interface IWalker
{
    Vector2 GetWalkerPosition();
    void MoveRight(float speed);
    void MoveLeft(float speed);
    void MoveUp(float speed);
    void MoveDown(float speed);
}
