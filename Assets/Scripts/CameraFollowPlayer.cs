using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{

    public Vector2 m_MovementSmooth;

    private Transform m_ActiveViking;
    public Transform ActiveViking
    {
        set
        {
            this.m_ActiveViking = value;
        }
    }
    private Transform m_Transform;

    // Use this for initialization
    void Start()
    {
        m_Transform = transform;
    }

    void FixedUpdate()
    {
        if (m_ActiveViking)
        {
            Vector2 velocity = Vector2.zero;
            float positionX = Mathf.SmoothDamp(m_Transform.position.x, m_ActiveViking.position.x, ref velocity.x, m_MovementSmooth.x);
            float positionY = Mathf.SmoothDamp(m_Transform.position.y, m_ActiveViking.position.y, ref velocity.y, m_MovementSmooth.y);

            m_Transform.position = new Vector3(positionX, positionY, m_Transform.position.z);
        }

    }
}
