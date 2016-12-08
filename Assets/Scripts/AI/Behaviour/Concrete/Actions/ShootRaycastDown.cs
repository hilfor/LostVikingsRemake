using UnityEngine;
using System.Collections;
using System;

public class ShootRaycastDown : IBTAction
{

    private BoxCollider2D cachedCollider;
    public bool Act(IContext context)
    {


        GameObject gameObject = ((ICharacter)context.GetVariable("ICharacter")).GetGameObject();
        Vector2 walkerPosition = ((IWalker)context.GetVariable("IWalker")).GetWalkerPosition();
        Vector2 raycastOffset = Vector2.zero;

        this.cachedCollider = gameObject.GetComponent<BoxCollider2D>();
        if (cachedCollider != null)
        {
            raycastOffset = cachedCollider.size;
            raycastOffset.x = 0;
        }
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(walkerPosition, direction, 0.001f,
            LayerMask.NameToLayer("LevelLayer"), raycastOffset.y / 2);
        raycastOffset.x = 3;
        Debug.DrawRay(walkerPosition - (raycastOffset / 2), direction, Color.green, 0.5f);
        return hit.collider != null;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
