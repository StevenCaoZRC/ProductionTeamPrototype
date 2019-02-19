using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool m_waterChildSelected = true;

    public Player m_waterChild;
    public Player m_forestChild;
    public GameObject m_pivotPoint;
    public float m_rotationSpeed = 0.1f;
    float t;
    Quaternion initial;
    Quaternion target;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayerPos();
    }

    public void SwitchPlayerPos()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(Rotation(m_waterChild.transform.rotation, 180));

            if (m_waterChildSelected)
            {
                Vector3 tempWaterPos = m_waterChild.transform.position;
                m_waterChild.transform.position = m_forestChild.transform.position;
                m_forestChild.transform.position = tempWaterPos;

                //m_waterChild.transform.RotateAround(m_pivotPoint.transform.position, new Vector3(0.0f, 1.0f, 0.0f), 180.0f);

                //Play anims
                m_waterChildSelected = false;
            }
            else
            {
                Vector3 tempforestPos = m_forestChild.transform.position;
                m_forestChild.transform.position = m_waterChild.transform.position;
                m_waterChild.transform.position = tempforestPos;
                //Play anims

                m_waterChildSelected = true;
            }
            Debug.Log("WaterSelected: " + m_waterChildSelected);
        }
    }

    //public IEnumerator Rotation(Quaternion degrees, float time)
    //{
    //    float distance = Vector3.Distance(m_waterChild.transform.position, m_forestChild.transform.position);
    //    while (distance > 0.499999999999999999f)
    //    {
    //        m_waterChild.transform.RotateAround(m_pivotPoint.transform.up, Vector3.up, time * Time.deltaTime);
    //        m_waterChild.transform.rotation = degrees;
    //        Debug.Log("Water position: " + distance);

    //        yield return null;
    //    }
    //}
}
