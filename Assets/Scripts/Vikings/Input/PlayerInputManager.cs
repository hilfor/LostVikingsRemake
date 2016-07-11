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
        InputState state = GetInputState();
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

    InputState GetInputState()
    {
        InputState inputState = new InputState(m_InputMap);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputState.CheckPressed(InputAction.LEFT);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputState.CheckPressed(InputAction.RIGHT);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputState.CheckPressed(InputAction.UP);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputState.CheckPressed(InputAction.DOWN);
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            inputState.CheckPressed(InputAction.SPECIAL_ACTION1);
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                inputState.CheckTriggered(InputAction.SPECIAL_ACTION1);
            }
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            inputState.CheckPressed(InputAction.SPECIAL_ACTION2);
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                inputState.CheckTriggered(InputAction.SPECIAL_ACTION2);
            }
        }

        return inputState;
    }

}
