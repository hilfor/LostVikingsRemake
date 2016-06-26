using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    IViking m_DefaultViking;

    public IViking DefaultViking
    {
        get
        {
            return this.DefaultViking;
        }
    }


}
