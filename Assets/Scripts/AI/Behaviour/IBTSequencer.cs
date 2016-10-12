using UnityEngine;
using System.Collections;

public interface IBTSequencer : IBTSelector
{
    void AppendCondition(IBTCondition condition);
}
