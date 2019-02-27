using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCharms : MonoBehaviour
{
    public GameObject m_character;
    public GameObject m_waterCharm;
    public GameObject m_forestCharm;
    // Start is called before the first frame update
    void Start()
    {
       if(m_character.GetComponent<PlayerControl>().GetIsLeading())
        {
            Debug.Log("hihihihi" + m_character.GetComponent<PlayerControl>().GetIsLeading());
            m_waterCharm.SetActive(true);
            m_forestCharm.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in update" + m_character.GetComponent<PlayerControl>().GetIsLeading());

        if (m_character != null)
        {
            if (m_character.GetComponent<PlayerControl>().GetIsLeading())
            {
                m_waterCharm.SetActive(true);
                m_forestCharm.SetActive(false);
            }
            else if (!m_character.GetComponent<PlayerControl>().GetIsLeading())
            {
                m_waterCharm.SetActive(false);
                m_forestCharm.SetActive(true);
            }
        }
        
    }
}
