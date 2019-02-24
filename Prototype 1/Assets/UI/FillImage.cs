using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FillImage : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float scale = 1.0f;
    //public float m_times = 5.0f;
    private float m_maxTimes = 5.0f;

    public RectTransform rectTransform;
    public Player m_child;

    private void Start()
    {
        m_maxTimes = m_child.GetAbilityCount();
    }

    // Update is called once per frame
    public void Update()
    {
        scale = m_child.GetAbilityCount() / m_maxTimes;

        rectTransform.localScale = new Vector3(rectTransform.localScale.x, scale, rectTransform.localScale.z);
    }


    //public void AdjustScale(float _numTimes, float _maxTimes)
    //{
    //    m_times = _numTimes;
    //    m_maxTimes = _maxTimes;
    //}

}
