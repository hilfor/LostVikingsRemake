using UnityEngine;
using System.Collections;
using System;

public class Eric : BaseViking
{

    public float m_SprintSpeed = 5f;
    public float m_JumpForce = 5f;

    bool m_ActivateSprint = false;


    public override void Action(InputAction action)
    {

        switch (action)
        {
            case InputAction.TRIGGER_SPECIAL_ACTION1:
                break;
            case InputAction.TRIGGER_SPECIAL_ACTION2:
                break;
        }
    }



    protected override void FrontHit(Collider2D collider)
    {
        base.Hit();
    }

    protected override void TopHit(Collider2D collider)
    {
        base.Hit();
    }


}
