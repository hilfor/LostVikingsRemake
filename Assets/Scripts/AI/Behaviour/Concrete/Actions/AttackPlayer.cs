public class AttackPlayer : IBTAction
{
    public bool Act(IContext context)
    {
        IEnemy enemy = (IEnemy)context.GetVariable("IEnemy");
        enemy.Attack();
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}