using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    ICharacter m_DefaultViking;

    public ICharacter DefaultViking
    {
        get
        {
            return this.DefaultViking;
        }
    }


}
