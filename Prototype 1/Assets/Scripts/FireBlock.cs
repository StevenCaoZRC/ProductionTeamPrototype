using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlock : Block
{
    bool fireBurning = true;
    GameObject m_waterFireIcon;

    private void Awake()
    {
        m_waterFireIcon = transform.GetChild(1).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_waterFireIcon.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Fire");
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
            //Skip platform
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            m_waterFireIcon.SetActive(false);

            fireBurning = false;
            m_isWalkable = true;
            m_blockType = BlockType.Ground;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (fireBurning)
            {
                m_waterFireIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_waterFireIcon.SetActive(false);
        }
    }
}
