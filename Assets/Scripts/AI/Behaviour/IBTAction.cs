using UnityEngine;
using System.Collections;

public interface IBTAction : IBTNode
{
    bool Act(IContext context);
}
