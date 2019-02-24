using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : Block
{
    public GameObject m_iceBlockPrefab;
    public GameObject m_waterLink;
    public Transform m_startBlock;
    public Transform m_endBlock;

    bool m_waterIsEmpty = true;

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
        }
    }

    IEnumerator SpawnIceAfterAnimation()
    {
        GameObject iceBlock = Instantiate(m_iceBlockPrefab, transform.position, Quaternion.identity);
        iceBlock.transform.parent = gameObject.transform;

        yield return new WaitForSeconds(2.5f);
        m_waterIsEmpty = false;
        m_blockType = BlockType.Ice;
        m_waterLink.SetActive(true);
        yield return null;
    }

    public void WaterWaitPosition(Transform _player, ref Vector3 _waitPos)
    {
        if(m_waterIsEmpty && !m_isWalkable)
        {
            Vector3 dist = _player.position - transform.position;
            float dotProduct = Vector3.Dot(dist, transform.forward);
            if(dotProduct == 1)
            {
                //Player is behind water block
                _waitPos = new Vector3(m_startBlock.position.x, _player.position.y, m_startBlock.position.z);   
            }
            else
            {
                //Player is infront of water block
                _waitPos = new Vector3(m_endBlock.position.x, _player.position.y, m_endBlock.position.z);

            }
        }
    }
}
