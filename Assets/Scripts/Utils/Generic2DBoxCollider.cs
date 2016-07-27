using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Generic2DBoxCollider : MonoBehaviour
{

    private BoxCollider2D m_BoxCollider;

    private Action<Collider2D> m_OnTriggerEnter = delegate { };
    private Action<Collider2D> m_OnTriggerExit = delegate { };
    private Action<Collider2D> m_OnTriggerStay = delegate { };

    public Action<Collider2D> OnTriggerEnter
    {
        set
        {
            m_OnTriggerEnter += value;
        }
    }

    public Action<Collider2D> OnTriggerStay
    {
        set
        {
            m_OnTriggerStay += value;
        }
    }

    public Action<Collider2D> OnTriggerExit
    {
        set
        {
            m_OnTriggerExit += value;
        }
    }


    void Awake()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("GenericCollider Enter " + collision.name);
        if (m_OnTriggerEnter.GetInvocationList().Length > 0)
        {
            m_OnTriggerEnter.Invoke(collision);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (m_OnTriggerExit.GetInvocationList().Length > 0)
        {
            m_OnTriggerExit.Invoke(collision);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("GenericCollider ");
        if (m_OnTriggerStay.GetInvocationList().Length > 0)
        {
            m_OnTriggerStay.Invoke(collision);
        }
    }
}
