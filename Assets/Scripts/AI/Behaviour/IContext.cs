using UnityEngine;
using System.Collections;

public interface IContext
{
    object GetVariable(string name);
    void SetVariable(string name, object value);
}
