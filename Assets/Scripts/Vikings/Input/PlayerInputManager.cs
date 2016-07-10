using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMotor m_PlayerMotor;

    void FixedUpdate()
    {
        InputAction action = CheckInput();
        if (action == InputAction.RIGHT_PRESSED || action == InputAction.LEFT_PRESSED)
        {
            m_PlayerMotor.Move(action == InputAction.RIGHT_PRESSED ? 1 : -1);
        }
        else
        {
            m_PlayerMotor.ExecuteAction(action);
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

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            return InputAction.TRIGGER_SPECIAL_ACTION2;
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            return InputAction.TRIGGER_SPECIAL_ACTION1;
        }

        return InputAction.NONE;
    }








}
