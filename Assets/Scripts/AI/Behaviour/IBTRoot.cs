using UnityEngine;
using System.Collections;

public interface IBTRoot 
{
    IExpectedBehavior GetExpectedBehavior(IContext context);
}
