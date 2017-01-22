using UnityEngine;
using System.Collections;

public class BVkng : MonoBehaviour
{

    private Rigidbody2D m_RigidBody;

    [SerializeField]
    private float m_MovementSpeed;


    private InputState m_InputState;
    public InputState InputState
    {
        set { m_InputState = value; }
        get { return m_InputState; }
    }


    // Use this for initialization
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void HandleMovement()
    {

    }

    void FixedUpdate()
    {



        HandleMovement();
    }

    void Reset()
    {

    }
}
