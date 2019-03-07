using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineGround : MonoBehaviour
{
    public GameObject m_forestVGIcon;
    GameObject m_vineBlock;

    // Start is called before the first frame update
    void Awake()
    {
        m_vineBlock = transform.parent.gameObject;
    }
    private void Start()
    {
        m_forestVGIcon.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            m_forestVGIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
             m_forestVGIcon.SetActive(false);
        }
    }
}
