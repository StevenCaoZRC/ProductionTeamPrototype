using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class FillImage : MonoBehaviour
{
    private float m_maxTimes;

    public Player m_child;
    public Image m_charm;
    public TextMeshProUGUI m_manaCount;

    private void Start()
    {
        Reset();
    }

    // Update is called once per frame
    public void Update()
    {
        float count = m_child.GetAbilityCount() / m_child.GetMaxAbilityCount();
        m_charm.fillAmount = count;
        m_manaCount.text = ((int)m_child.GetAbilityCount()).ToString();
    }

    public void Reset()
    {
        m_maxTimes = m_child.GetMaxAbilityCount();
        m_charm.fillAmount = m_child.GetAbilityCount() / m_maxTimes;
    }
}