﻿using UnityEngine;
using System.Collections;
using System;

public class SetPlayerStateToClimbing : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetState().CanClimb = true;
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
