using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class InputActionList : ScriptableObject
{
    [SerializeField]
    public InputMap[] InputActions;
}
