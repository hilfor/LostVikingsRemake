using UnityEngine;
using System.Collections;

public class ChildJumping : MonoBehaviour
{
    public float m_JumpHeight;
    public float m_TransitionJumps;
    private Transform m_Transform;
    private Vector2 m_MaxJumpPosition;
    private Vector2 m_LowestPosition;

    private float m_Transistion;
    private float m_TransitionDirection;

    void Start()
    {
        m_Transform = transform;
        m_MaxJumpPosition = m_Transform.position;
        m_MaxJumpPosition.y += m_JumpHeight;
        m_LowestPosition = m_Transform.position;

        m_Transistion = 0;
        m_TransitionDirection = 1;
    }

    void FixedUpdate()
    {
        if (m_TransitionDirection == 1)
        {
            m_Transform.position = Vector2.Lerp(m_Transform.position, m_MaxJumpPosition, m_Transistion);
            m_Transistion += m_TransitionJumps;
            if (Vector2.Distance(m_Transform.position, m_MaxJumpPosition) <= 0.01)
            {
                m_Transistion = 0;
                m_TransitionDirection *= -1;
            }
        }
        else
        {
            m_Transform.position = Vector2.Lerp(m_Transform.position, m_LowestPosition, m_Transistion);
            m_Transistion += m_TransitionJumps;
            if (Vector2.Distance(m_Transform.position, m_LowestPosition) <= 0.01)
            {
                m_Transistion = 0;
                m_TransitionDirection *= -1;
            }
        }
    }

}
