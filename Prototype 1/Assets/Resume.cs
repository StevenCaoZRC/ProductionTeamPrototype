using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Resume : MonoBehaviour, IPointerClickHandler
{
    PlayerControl m_playerControl;
    // Start is called before the first frame update
    void Start()
    {
        m_playerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        m_playerControl.m_menuActivated = false;
        Debug.Log("THE CURSOR IS ON A UI ELEMENT");
    }
}
