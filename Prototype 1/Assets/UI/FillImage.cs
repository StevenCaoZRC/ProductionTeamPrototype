using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FillImage : MonoBehaviour
{
    private float m_maxTimes;

    public Player m_child;
    public Image m_charm;

    private void Start()
    {
        m_maxTimes = m_child.GetAbilityCount();
        m_charm.fillAmount = 1.0f;
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (m_child.GetAbilityCount() != 0)
        {
            m_charm.fillAmount = m_child.GetAbilityCount() / m_maxTimes;
        }

    }


    public void Reset()
    {
        m_maxTimes = m_child.GetAbilityCount();
        m_charm.fillAmount = 1.0f;
    }

}
