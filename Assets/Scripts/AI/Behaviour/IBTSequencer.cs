using UnityEngine;
using System.Collections;

public interface IBTSequencer : IBTNode
{
    IBTSequencer AppendNode(IBTNode node);
}
