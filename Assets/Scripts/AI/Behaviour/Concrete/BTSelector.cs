using UnityEngine;
using System.Collections.Generic;
using System;

public class BTSelector : IBTSelector
{
    private List<IBTCondition> conditions;

    public BTSelector()
    {
        this.conditions = new List<IBTCondition>();
    }

    public void AppendCondition(IBTCondition condition)
    {
        this.conditions.Add(condition);
    }

    public bool Process(IContext context)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].ConditionPassed(context))
            {
                return true;
            }
        }
        return false;
    }
}
