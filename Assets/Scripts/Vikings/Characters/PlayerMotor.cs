using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{
    public ICharacter m_ActiveViking = null;

    void Start()
    {
        m_ActiveViking = GetComponent<ICharacter>();
    }

    public void SetActiveViking(ICharacter activeViking)
    {
        m_ActiveViking = activeViking;
    }

    void Move(float direction)
    {
        if (m_ActiveViking == null)
            return;
        float normalizedSpeed = Mathf.Abs(direction);
        if (direction < 0)
        {
            m_ActiveViking.MoveLeft(normalizedSpeed);
        }
        else
        {
            m_ActiveViking.MoveRight(normalizedSpeed);
        }
    }

    public void ExecuteAction(InputState inputState)
    {
        if (m_ActiveViking == null)
            return;
        if (inputState.CheckPressed(InputAction.RIGHT) || inputState.CheckPressed(InputAction.LEFT))
        {
            Move(inputState.CheckPressed(InputAction.RIGHT) ? 1 : -1);
        }
        else
        {
            m_ActiveViking.Action(inputState);
        }

        //switch (state)
        //{
        //    //case InputAction.JUMP:
        //    //    m_CurrentViking.Jump();
        //    //    break;
        //    case InputAction.NONE:
        //        m_CurrentViking.NoInput();
        //        break;
        //    default:
        //        m_CurrentViking.Action(state);
        //        break;
        //}


    }


}
