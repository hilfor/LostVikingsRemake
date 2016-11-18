public class StopAttackPlayer : IBTAction
{
    public bool Act(IContext context)
    {
        IEnemy enemy = (IEnemy)context.GetVariable("IEnemy");
        enemy.StopAttackPlayer();
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}