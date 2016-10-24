using UnityEngine;
using System.Collections;

public interface IBTCondition: IBTNode
{
    bool ConditionPassed(IContext context);
}
