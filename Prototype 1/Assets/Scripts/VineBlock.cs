using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VineBlock : Block
{
    bool m_spawned = true;
    public GameObject m_forestVBIcon;

    //GameObject m_waterIcon;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public override void Reset()
    {
        m_blockType = BlockType.Vine;
        m_spawned = false;
        m_forestVBIcon.SetActive(false);
    }
    public bool GetVinesSpawned()
    {
        return m_spawned;
    }

    public void SetVinesSpawned(bool _spawned)
    {
        m_spawned = _spawned;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            m_forestVBIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_forestVBIcon.SetActive(false);
        }
    }
}
