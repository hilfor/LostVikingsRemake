using UnityEngine;
using System;
using System.Xml;
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
        //xml.ChildNodes
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
        return null;
    }
    private IBTAction CreateAction(XmlNode node)
    {
        return null;
    }
    private IBTSequencer CreateSequence(XmlNode node)
    {
        return null;
    }
    private IBTPositiveSequencer CreatePositiveSequence(XmlNode node)
    {
        return null;
    }
    private IBTInvertor CreateInverter(XmlNode node)
    {
        return null;
    }
    private IBTSelector CreateSelector(XmlNode node)
    {
        return null;
    }
}
