using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionList actionsList;
    [SerializeField]
    private PlayerMotor m_PlayerMotor;
    private Hashtable m_InputMap;

    void Awake()
    {
        m_InputMap = new Hashtable();
    }

    void FillInputMap()
    {
        InputMap[] actions = actionsList.InputActions;

        for (int i = 0; i < actions.Length; i++)
        {
            m_InputMap.Add(actions[i].action, actions[i].key);
        }
    }

    void FixedUpdate()
    {
        InputState state = CheckInput();
        m_PlayerMotor.ExecuteAction(state);

        //if (state == InputAction.RIGHT_PRESSED || state == InputAction.LEFT_PRESSED)
        //{
        //    m_PlayerMotor.Move(state == InputAction.RIGHT_PRESSED ? 1 : -1);
        //}
        //else
        //{
        //    m_PlayerMotor.ExecuteAction(state);
        //}
    }

    InputState CheckInput()
    {
        InputState inputState = new InputState(m_InputMap);

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //return InputAction.LEFT_PRESSED;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //          return InputAction.RIGHT_PRESSED;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //   return InputAction.UP_PRESSED;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //    return InputAction.DOWN_PRESSED;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //    return InputAction.SPECIAL_ACTION2;
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            //   return InputAction.SPECIAL_ACTION1;
        }

        return inputState;
    }








}
