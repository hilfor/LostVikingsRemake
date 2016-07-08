using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMotor m_PlayerMotor;

    void Start()
    {
    }

    void FixedUpdate()
    {
        InputAction action = CheckInput();
        if (action != InputAction.NONE)
        {
            if (action == InputAction.RIGHT_PRESSED || action == InputAction.LEFT_PRESSED)
            {
                m_PlayerMotor.Move(action == InputAction.RIGHT_PRESSED ? 1 : -1);
            }
            else
            {
                m_PlayerMotor.ExecuteAction(action);
            }

        }
    }

    InputAction CheckInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return InputAction.LEFT_PRESSED;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            return InputAction.RIGHT_PRESSED;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            return InputAction.UP_PRESSED;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            return InputAction.DOWN_PRESSED;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            return InputAction.JUMP;
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            return InputAction.SPECIAL_ACTION;
        }

        return InputAction.NONE;
    }








}
