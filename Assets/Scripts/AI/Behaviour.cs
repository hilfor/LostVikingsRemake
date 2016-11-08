using UnityEngine;
using System;
using System.Xml;
using System.Reflection;
using System.Collections;

public class Behaviour : MonoBehaviour
{

    public enum BehaviorTypes
    {
        DragonBasic,
        PlayerBasic
    }

    public XmlDocument ReadFile(string fileName)
    {
        UnityEngine.Object dragonBasic = Resources.Load("AI/Behaviours/" + fileName);
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(dragonBasic.ToString());
        return xml;
    }

    public IBTNode GetTree(BehaviorTypes type)
    {
        XmlDocument xml = ReadFile(Enum.GetName(typeof(BehaviorTypes), type));
        return CreateTreeFromXML(xml.ChildNodes);
        //return null;
    }

    private IBTNode CreateTreeFromXML(XmlNodeList xmlChildren)
    {
        IBTSequencer btNode = new BTSequencer();

        foreach (XmlNode node in xmlChildren)
        {
            if (node.ChildNodes.Count > 0)
            {
                IBTNode childrenNode = CreateTreeFromXML(node.ChildNodes);
                btNode.AppendNode(CreateBtNode(node, childrenNode));
            }
            else
            {
                btNode.AppendNode(CreateBtNode(node));
            }

        }
        return btNode;
    }

    private IBTNode CreateBtNode(XmlNode node, IBTNode children)
    {
        IBTNode btNode = null;
        switch (node.Name)
        {
            case "sequence":
                btNode = CreateSequence(node).AppendNode(children);
                break;
            case "inverter":
                btNode = CreateInverter(node).SetNode(children);
                break;
            case "positiveSequence":
                btNode = CreatePositiveSequence(node).AppendNode(children);
                break;
        }
        return btNode;
    }

    private IBTNode CreateBtNode(XmlNode node)
    {
        IBTNode btNode = null;
        switch (node.Name)
        {
            case "action":
                btNode = CreateAction(node);
                break;
            case "condition":
                btNode = CreateCondition(node);
                break;

        }
        return btNode;
    }

    private IBTCondition CreateCondition(XmlNode node)
    {
        string conditionClassName = node.Attributes["name"].Value;
        return (IBTCondition)CreateReflectionObject(conditionClassName);
    }
    private IBTAction CreateAction(XmlNode node)
    {
        string actionClassName = node.Attributes["name"].Value;
        return (IBTAction)CreateReflectionObject(actionClassName);
    }
    private IBTSequencer CreateSequence(XmlNode node)
    {
        string sequenceClassName = node.Attributes["name"].Value;
        return (IBTSequencer)CreateReflectionObject(sequenceClassName);
    }
    private IBTPositiveSequencer CreatePositiveSequence(XmlNode node)
    {
        string positiveSequencerClassName = node.Attributes["name"].Value;
        return (IBTPositiveSequencer)CreateReflectionObject(positiveSequencerClassName);
    }
    private IBTInvertor CreateInverter(XmlNode node)
    {
        string inverterClassName = node.Attributes["name"].Value;
        return (IBTInvertor)CreateReflectionObject(inverterClassName);
    }
    private IBTSelector CreateSelector(XmlNode node)
    {
        string selectorClassName = node.Attributes["name"].Value;
        return (IBTSelector)CreateReflectionObject(selectorClassName);
    }

    private object CreateReflectionObject(string clazz)
    {
        Type t = Type.GetType(clazz);
        return Activator.CreateInstance(t);
    }
}


public class CheckNotAlreadyAttacking : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return !((ICharacter)context.GetVariable("ICharacter")).GetState().Attacking;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}

public class CheckIfArrivedAtNextWaypoint : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        IFollower follower = (IFollower)context.GetVariable("IFollower");
        return follower.GetNextWaypoint().Reached((IWalker)follower);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}

public class SetNextWaypoint : IBTAction
{
    public bool Act(IContext context)
    {
        IFollower follower = (IFollower)context.GetVariable("IFollower");
        follower.SetNextWaypoint(follower.GetNextWaypoint());
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}

public class WalkToNextWaypoint : IBTAction
{
    public bool Act(IContext context)
    {
        IWalker walker = (IWalker)context.GetVariable("IWalker");
        IFollower follower = (IFollower)context.GetVariable("IFollower");
        FacingDirection facingDirection = walker.GetFacingDirection();
        float maxWalkingSpeed = (float)context.GetVariable("maxWalkingSpeed");

        Vector2 myPosition = walker.GetWalkerTransform().position;
        Vector2 direction = follower.GetNextWaypoint().GetWaypointPosition() - myPosition;
        direction.Normalize();

        if (direction.x > 0)
        {
            if (facingDirection == FacingDirection.LEFT)
                walker.ChangeDirection(FacingDirection.RIGHT);
            walker.MoveRight(maxWalkingSpeed);
        }
        else if (direction.x < 0)
        {
            if (facingDirection == FacingDirection.RIGHT)
                walker.ChangeDirection(FacingDirection.LEFT);
            walker.MoveLeft(maxWalkingSpeed);
        }
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}

public class CheckIfCollidedWithPlayer : IBTCondition
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

public class AttackPlayer : IBTAction
{
    public bool Act(IContext context)
    {
        IEnemy enemy = (IEnemy)context.GetVariable("IEnemy");
        enemy.AttackPlayer();
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}

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