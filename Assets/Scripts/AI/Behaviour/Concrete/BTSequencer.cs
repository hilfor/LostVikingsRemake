using System;
using System.Collections.Generic;
public class BTSequencer : IBTSequencer
{

    private List<IBTCondition> conditions;

    public BTSequencer()
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
            if (!conditions[i].ConditionPassed(context))
            {
                return false;
            }
        }

        return true;
    }

}
