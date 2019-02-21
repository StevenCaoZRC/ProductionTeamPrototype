using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : Block
{
    public GameObject m_iceBlockPrefab;

    bool m_waterIsEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateIce();
        }
    }

    public override void Reset()
    {
        gameObject.layer = LayerMask.NameToLayer("Water");
        m_waterIsEmpty = true;
        m_isWalkable = false;
        m_blockType = BlockType.Fire;
    }

    public void CreateIce()
    {
        if(m_waterIsEmpty)
        {
            GameObject iceBlock = Instantiate(m_iceBlockPrefab, transform.position, Quaternion.identity);
            iceBlock.transform.parent = gameObject.transform;
            m_waterIsEmpty = false;
            m_isWalkable = true;
            m_blockType = BlockType.Ice;
            gameObject.layer = LayerMask.NameToLayer("IceBlock");
        }
        
    }
}
