﻿using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{
    private ICharacter m_ActiveViking = null;

    private Camera m_MainCamera;

    private Transform m_Olaf;
    private Transform m_Eric;
    private Transform m_Baelog;

    private CameraFollowPlayer m_CameraFollow;

    void Start()
    {
        //m_ActiveViking = GetComponent<ICharacter>();

        m_MainCamera = Camera.main;
        m_CameraFollow = m_MainCamera.GetComponent<CameraFollowPlayer>();

        m_Olaf = GameObject.Find("Olaf").GetComponent<Transform>();
        //m_Eric = GameObject.Find("Eric").GetComponent<Transform>();
        //m_Baelog = GameObject.Find("Baelog").GetComponent<Transform>();


        if (m_CameraFollow)
        {
            Debug.Log("Setting default viking to Olaf");
            m_CameraFollow.ActiveViking = m_Olaf;
            m_ActiveViking = m_Olaf.GetComponent<ICharacter>();
        }
    }

    void MoveHorizontaly(float direction)
    {
        //if (m_ActiveViking == null)
        //    return;
        float normalizedSpeed = Mathf.Abs(direction);
        if (direction < 0)
        {
            //Debug.Log("Moving " + m_ActiveViking + " Left");
            m_ActiveViking.MoveLeft(normalizedSpeed);
        }
        else
        {
            //Debug.Log("Moving " + m_ActiveViking + " Right");
            m_ActiveViking.MoveRight(normalizedSpeed);
        }
    }

    void MoveVertically(float direction)
    {
        float normalizedSpeed = Mathf.Abs(direction);
        if (direction < 0)
        {
            //Debug.Log("Moving " + m_ActiveViking + " Left");
            m_ActiveViking.MoveDown(normalizedSpeed);
        }
        else
        {
            //Debug.Log("Moving " + m_ActiveViking + " Right");
            m_ActiveViking.MoveUp(normalizedSpeed);
        }
    }

    public void ExecuteAction(InputState inputState)
    {

        if (m_ActiveViking == null)
        {
            Debug.LogWarning("NO active vikings");
            return;
        }

        if (inputState.CheckNoInput())
        {
            m_ActiveViking.NoInput();
            return;
        }

        if (inputState.CheckTriggered(InputAction.SELECT_BAELOG))
        {
            ChangeCameraFollowViking(m_Baelog);
            m_ActiveViking = m_Baelog.GetComponent<ICharacter>();
        }
        else if (inputState.CheckTriggered(InputAction.SELECT_ERIC))
        {
            ChangeCameraFollowViking(m_Eric);
            m_ActiveViking = m_Eric.GetComponent<ICharacter>();
        }
        else if (inputState.CheckTriggered(InputAction.SELECT_OLAF))
        {
            ChangeCameraFollowViking(m_Olaf);
            m_ActiveViking = m_Olaf.GetComponent<ICharacter>();
        }


        if (inputState.CheckPressed(InputAction.RIGHT) || inputState.CheckPressed(InputAction.LEFT))
        {
            MoveHorizontaly(inputState.CheckPressed(InputAction.RIGHT) ? 1 : -1);
        }
        else if (inputState.CheckPressed(InputAction.DOWN) || inputState.CheckPressed(InputAction.UP))
        {
            MoveVertically(inputState.CheckPressed(InputAction.UP) ? 1 : -1);
        }
        else
        {
            m_ActiveViking.Action(inputState);
        }

    }

    void ChangeCameraFollowViking(Transform activeViking)
    {
        if (m_CameraFollow)
        {
            Debug.Log("Changing viking to " + activeViking.name);
            m_CameraFollow.ActiveViking = activeViking;
        }
    }

}
