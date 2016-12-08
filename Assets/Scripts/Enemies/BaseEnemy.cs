using UnityEngine;
using System.Collections;
using System;

public abstract class BaseEnemy: MonoBehaviour, IEnemy
{
    public void Action(InputState action)
    {
        throw new NotImplementedException();
    }
    public void NoInput()
    {
        throw new NotImplementedException();
    }

    
    public abstract void Attack();
    public abstract AnimationState GetAnimationState();
    public abstract State GetState();
    public abstract bool IsCollidedWithPlayer();
    public abstract void ReceiveDamage(int damage);
    public abstract void StopAttackPlayer();

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
