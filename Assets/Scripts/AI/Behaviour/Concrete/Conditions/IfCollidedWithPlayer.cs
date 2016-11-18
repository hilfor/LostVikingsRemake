public class IfCollidedWithPlayer : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        IEnemy enemy = (IEnemy)context.GetVariable("IEnemy");

        return enemy.IsCollidedWithPlayer();
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}