﻿using UnityEngine;
using System.Collections;

public interface IWalker
{
    Vector2 GetWalkerPosition();
    Transform GetWalkerTransform();
    FacingDirection GetFacingDirection();
    void ChangeDirection(FacingDirection newDirection);
    void MoveRight(float speed);
    void MoveLeft(float speed);
    void MoveUp(float speed);
    void MoveDown(float speed);
}
