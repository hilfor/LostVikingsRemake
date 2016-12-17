using UnityEngine;
using System.Collections;

public interface IExpectedBehavior 
{
    IExpectedBehavior Join(IExpectedBehavior expectedBehaviour);
}
