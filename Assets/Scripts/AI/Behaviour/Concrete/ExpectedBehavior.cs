using UnityEngine;
using System.Collections;
using System;

public class ExpectedBehavior : IExpectedBehavior
{
    public IExpectedBehavior Join(IExpectedBehavior expectedBehaviour)
    {
        throw new NotImplementedException();
    }
}
