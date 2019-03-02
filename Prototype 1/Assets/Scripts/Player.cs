using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Variables

    public enum Element {None, Water, Forest};
    public Animator m_childAnim;

    [SerializeField]
    protected Element m_charaElement = Element.None;
    protected bool m_isActive = false;
    protected bool m_isCasting = false;
    //protected bool m_isLeading = false;

    protected float m_currAbilityCount = 5;
    protected float m_maxAbilityCount = 5;

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
        m_currAbilityCount = newAmount;
    }

    public float GetAbilityCount()
    {
        return m_currAbilityCount;
    }

    public void SetMaxAbilityCount(int newAmount)
    {
        m_maxAbilityCount = newAmount;
    }

    public float GetMaxAbilityCount()
    {
        return m_maxAbilityCount;
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
    //public void SetIsLeading(bool _leading)
    //{
    //    m_isLeading = _leading;
    //}

    //public bool GetIsLeading()
    //{
    //    return m_isLeading;
    //}

    public void PlaySwitchAnim()
    {
        m_childAnim.SetTrigger("Fidget");
    }

    public virtual void SpellOne(GameObject _object) { }
    public virtual void SpellTwo(GameObject _object) { }
    public virtual void Reset() { }

}
