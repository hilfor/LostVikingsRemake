using UnityEngine;
using System.Collections;

public interface IPlayer : ICharacter {
    void SetCanClimb(bool canClimb);
    bool ReachedTopLadder();
    bool ReachedBottomLadder();
}
