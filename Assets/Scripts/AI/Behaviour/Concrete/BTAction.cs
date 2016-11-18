using System;

public class BTAction : IBTAction
{
    private Action<IContext> action;

    public BTAction(Action<IContext> action)
    {
        this.action = action;
    }

    public bool Act(IContext context)
    {
        this.action.Invoke(context);
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }

}
