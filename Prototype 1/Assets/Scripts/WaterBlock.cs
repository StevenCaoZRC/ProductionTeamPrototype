using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : Block
{
    public GameObject m_iceBlockPrefab;
   
    public GameObject m_waterLink;
    public Transform m_startBlock;
    public Transform m_endBlock;
    AudioManager AudioMgr;
    bool m_waterIsEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        AudioMgr = FindObjectOfType<AudioManager>();
        AudioMgr.Play("Water");
        AudioMgr.Stop("Freeze");

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Reset()
    {
        m_waterIsEmpty = true;
        m_isWalkable = false;
        m_blockType = BlockType.Water;
        m_waterLink.SetActive(false);
    }

    public void CreateIce()
    {
        if (m_waterIsEmpty)
        {
            StartCoroutine(SpawnIceAfterAnimation());
            FindObjectOfType<AudioManager>().Play("Freeze");
        }
        
    }

    IEnumerator SpawnIceAfterAnimation()
    {
        Debug.Log("Spawning water block");
        GameObject iceBlock = Instantiate(m_iceBlockPrefab, transform.position, Quaternion.identity);
        iceBlock.transform.parent = gameObject.transform;
        
        yield return new WaitForSeconds(2.5f);
        m_waterIsEmpty = false;
        m_blockType = BlockType.Ice;
        m_waterLink.SetActive(true);
       
        yield return null;
    }
}
