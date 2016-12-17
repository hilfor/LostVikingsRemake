using UnityEngine;
using System.Collections;

public interface IBTComposeableBehavior 
{
    IExpectedBehavior ComposeBehavior(IContext context);
}
