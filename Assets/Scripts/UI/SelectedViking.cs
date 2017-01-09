using UnityEngine;
using System.Collections;

public class SelectedViking : MonoBehaviour
{

    [SerializeField]
    private GameObject m_EricAvatar;
    [SerializeField]
    private GameObject m_BaelogAvatar;
    [SerializeField]
    private GameObject m_OlafAvatar;

    [SerializeField]
    private GameObject m_SelectOverlayPrefab;

    private GameObject m_SelectOverlay;

    public void SelectionChanged(BaseViking newelySelectedViking)
    {
        if (!m_SelectOverlay)
        {
            m_SelectOverlay = Instantiate(m_SelectOverlayPrefab, Vector2.zero, Quaternion.identity) as GameObject;
        }

        
        if (newelySelectedViking is Olaf)
        {
            m_SelectOverlay.transform.position = m_OlafAvatar.transform.position;
        }
        else if (newelySelectedViking is Eric)
        {
            m_SelectOverlay.transform.position = m_EricAvatar.transform.position;
        }
        else if (newelySelectedViking is Baelog)
        {
            m_SelectOverlay.transform.position = m_BaelogAvatar.transform.position;
        }
    }


}
