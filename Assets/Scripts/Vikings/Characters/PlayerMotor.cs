using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{

    ICharacter m_CurrentViking;

    public void Move(float direction)
    {
        if (direction < 0)
        {
            m_CurrentViking.MoveLeft(direction);
        }
        else
        {
            m_CurrentViking.MoveRight(direction);
        }
    }

    public void ExecuteAction(InputAction action)
    {
        if (action == InputAction.JUMP)
        {
            m_CurrentViking.Jump();
        }

        m_CurrentViking.Action(action);
    }


}
