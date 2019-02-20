using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Variables

    public enum Element {None, Water, Forest};

    protected int m_abilityCount = 3;
    protected Element m_charaElement = Element.None;
    protected bool m_isActive;
    protected bool m_isCasting;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetAbilityCount(int newAmount)
    {
        m_abilityCount = newAmount;
    }

    public int GetAbilityCount()
    {
        return m_abilityCount;
    }

    public Element GetElement()
    {
        return m_charaElement;
    }

    
}
