using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : Block
{
    public GameObject m_iceBlockPrefab;
   
    public GameObject m_waterLink;
    AudioManager AudioMgr;
    GameObject m_waterIcon;
    bool m_waterIsEmpty = true;

    private void Awake()
    {
        m_waterIcon = transform.GetChild(1).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        AudioMgr = FindObjectOfType<AudioManager>();
        FindObjectOfType<AudioManager>().Play("Water");
        FindObjectOfType<AudioManager>().Stop("Freeze");

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Reset()
    {
        m_waterIcon.SetActive(false);

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
            FindObjectOfType<AudioManager>().PlayOnce("Freeze");
        }
        
    }

    IEnumerator SpawnIceAfterAnimation()
    {
        Debug.Log("Spawning water block");
        GameObject iceBlock = Instantiate(m_iceBlockPrefab, transform.position, Quaternion.identity);
        iceBlock.transform.parent = gameObject.transform;

        yield return new WaitForSeconds(2.3f);
        m_waterIsEmpty = false;
        m_waterIcon.SetActive(m_waterIsEmpty);

        m_blockType = BlockType.Ice;
        m_waterLink.SetActive(true);
       
        yield return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(m_waterIsEmpty)
            {
                m_waterIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_waterIcon.SetActive(false);
        }
    }
}
