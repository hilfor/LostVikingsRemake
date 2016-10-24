using UnityEngine;
using System.Collections;
using System;

public class Context : IContext
{
    private Hashtable variablesHash;

    public Context()
    {
        variablesHash = new Hashtable();
    }

    public object GetVariable(string name)
    {
        if (variablesHash.ContainsKey(name))
        {
            return variablesHash[name];
        }
        return null;
    }

    public void SetVariable(string name, object value)
    {
        variablesHash[name] = value;
    }

}
