using UnityEngine;
using System.Collections;

public interface IBTSelector : IBTSelector
{
    void AppendCondition(IBTCondition condition);

}
