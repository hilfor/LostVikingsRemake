using UnityEngine;
using System.Collections;

public interface IBTCondition
{
    bool ConditionPassed(IContext context);
}
