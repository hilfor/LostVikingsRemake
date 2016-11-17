using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InputState
{

    private Hashtable m_InputMap;
    private HashSet<KeyCode> m_Triggered;
    private HashSet<KeyCode> m_Pressed;

    public HashSet<KeyCode> TriggeredButtons
    {
        get
        {
            return this.m_Triggered;
        }
    }

    public HashSet<KeyCode> PressedButtons
    {
        get
        {
            return this.m_Pressed;
        }
    }


    public InputState(Hashtable actionsMap)
    {

        this.m_Triggered = new HashSet<KeyCode>();
        this.m_Pressed = new HashSet<KeyCode>();
        this.m_InputMap = actionsMap;
    }

    public void SetTriggered(KeyCode key)
    {
        m_Triggered.Add(key);
    }

    public void SetPressed(KeyCode key)
    {
        m_Pressed.Add(key);
    }

    public void SetTriggered(InputAction action)
    {
        if (m_InputMap.Contains(action))
            m_Triggered.Add((KeyCode)m_InputMap[action]);
    }

    public void SetPressed(InputAction action)
    {
        if (m_InputMap.Contains(action))
            m_Pressed.Add((KeyCode)m_InputMap[action]);
    }

    public bool CheckTriggered(KeyCode key)
    {
        return m_Triggered.Contains(key);
    }

    public bool CheckPressed(KeyCode key)
    {
        return m_Pressed.Contains(key);
    }

    public bool CheckPressedOrTriggered(KeyCode key)
    {
        return m_Pressed.Contains(key) || m_Triggered.Contains(key);
    }

    public bool CheckPressedOrTriggered(InputAction action)
    {
        if (m_InputMap.Contains(action))
        {
            return m_Triggered.Contains((KeyCode)m_InputMap[action]) || m_Pressed.Contains((KeyCode)m_InputMap[action]);
        }
        return false;
    }

    public bool CheckTriggered(InputAction action)
    {
        if (m_InputMap.Contains(action))
        {
            return m_Triggered.Contains((KeyCode)m_InputMap[action]);
        }

        return false;
    }

    public bool CheckPressed(InputAction action)
    {
        if (m_InputMap.Contains(action))
        {
            return m_Pressed.Contains((KeyCode)m_InputMap[action]);
        }

        return false;
    }

    public bool CheckNoInput()
    {
        return m_Pressed.Count == 0 && m_Triggered.Count == 0;
    }

}
