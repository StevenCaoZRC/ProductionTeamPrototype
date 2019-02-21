﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Variables

    public enum Element {None, Water, Forest};

    [SerializeField]
    protected Element m_charaElement = Element.None;
    protected bool m_isActive = false;
    protected bool m_isCasting = false;
    protected int m_abilityCount = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    public Element GetElement()
    {
        return m_charaElement;
    }

    public void SetAbilityCount(int newAmount)
    {
        m_abilityCount = newAmount;
    }

    public int GetAbilityCount()
    {
        return m_abilityCount;
    }

    public void SetIsCasting(bool _casting)
    {
        m_isCasting = _casting;
    }

    public bool GetIsCasting()
    {
        return m_isCasting;
    }

    public void SetIsActive(bool _active)
    {
        m_isActive = _active;
    }

    public bool GetIsActive()
    {
        return m_isActive;
    }
    
    public virtual void SpellOne(GameObject _object) { }
    public virtual void SpellTwo(GameObject _object) { }
}