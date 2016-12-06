using UnityEngine;
using System.Collections;

public interface IPlayer : ICharacter {

    bool ReachedTopLadder();
    bool ReachedBottomLadder();

    void ExecuteAction1();
    void ExecuteAction2();

    InputState GetInputState();
}
