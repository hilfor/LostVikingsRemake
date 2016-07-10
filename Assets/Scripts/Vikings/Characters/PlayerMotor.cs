using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{
    public ICharacter m_CurrentViking;
    
    void Start()
    {
        m_CurrentViking = GetComponent<ICharacter>();
    }

    public void Move(float direction)
    {
        float normalizedSpeed = Mathf.Abs(direction);
        if (direction < 0)
        {
            m_CurrentViking.MoveLeft(normalizedSpeed);
        }
        else
        {
            m_CurrentViking.MoveRight(normalizedSpeed);
        }
    }

    public void ExecuteAction(InputAction action)
    {

        switch (action)
        {
            //case InputAction.JUMP:
            //    m_CurrentViking.Jump();
            //    break;
            case InputAction.NONE:
                m_CurrentViking.NoInput();
                break;
            default:
                m_CurrentViking.Action(action);
                break;
        }


    }


}
