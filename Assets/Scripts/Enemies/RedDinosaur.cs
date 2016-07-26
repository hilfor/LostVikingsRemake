using UnityEngine;
using System.Collections;

public class RedDinosaur : MonoBehaviour, IEnemy
{

    [SerializeField]
    private Generic2DBoxCollider m_GroundCollider;
    [SerializeField]
    private Generic2DBoxCollider m_FrontCollider;
    [SerializeField]
    private IWaypoint m_StartWaypoint;

    private IWaypoint m_NextWaypoint;
    private Animator m_Animator;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
