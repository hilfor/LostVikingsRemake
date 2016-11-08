using UnityEngine;
using System.Collections;

public interface IEnemy: ICharacter {
    bool IsCollidedWithPlayer();
    void AttackPlayer();
    void StopAttackPlayer();

}
