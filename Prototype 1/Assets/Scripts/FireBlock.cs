using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlock : Block
{
    bool fireBurning = true;

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
        fireBurning = true;
        m_isWalkable = false;
        m_blockType = BlockType.Fire;
    }

    public void PutOutFire()
    {
        if(fireBurning)
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            fireBurning = false;
            m_isWalkable = true;
            m_blockType = BlockType.Ground;
        }
        
    }
}
