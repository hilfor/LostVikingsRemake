using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
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
        m_PlayerMotor = GetComponent<PlayerMotor>();
        FillInputMap();
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
        if (m_PlayerMotor)
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
            inputState.SetPressed(InputAction.LEFT);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputState.SetPressed(InputAction.RIGHT);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputState.SetPressed(InputAction.UP);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputState.SetPressed(InputAction.DOWN);
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            inputState.SetPressed(InputAction.SPECIAL_ACTION1);
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                inputState.SetTriggered(InputAction.SPECIAL_ACTION1);
            }
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            inputState.SetPressed(InputAction.SPECIAL_ACTION2);
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                inputState.SetTriggered(InputAction.SPECIAL_ACTION2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inputState.SetTriggered(InputAction.SELECT_OLAF);
            inputState.SetTriggered(InputAction.CHANGE_VIKING);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inputState.SetTriggered(InputAction.SELECT_ERIC);
            inputState.SetTriggered(InputAction.CHANGE_VIKING);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inputState.SetTriggered(InputAction.SELECT_BAELOG);
            inputState.SetTriggered(InputAction.CHANGE_VIKING);
        }

        return inputState;
    }

}
