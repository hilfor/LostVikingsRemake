using UnityEngine;
using System.Collections;

public interface IBTPositiveSequencer : IBTNode
{
    IBTPositiveSequencer AppendNode(IBTNode node);
}
