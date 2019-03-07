using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WaterChild : Player
{
    AudioManager AudioMger;
    public GameObject m_waterSplashPrefab;
    public GameObject m_waterCastPrefab;
    public GameObject m_waterPoint;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        AudioMger = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public override void Reset()
    {
        m_charaElement = Element.Water;
        m_currAbilityCount = LevelLoader.GetInstance().GetLvlWaterMana();
        m_maxAbilityCount = LevelLoader.GetInstance().GetLvlMaxWaterMana();
    }

    public override void SpellOne(GameObject _fire)
    {
        //put out fire
        if(m_currAbilityCount > 0 && !m_isCasting)
        {
            //m_waterPoint
            m_currAbilityCount -= 1;
            m_isCasting = true;
            StartCoroutine(PutOutFire(_fire));
           
        }
    }
    public override void SpellTwo(GameObject _waterBlock)
    {
        //Create ice block in river
        if (m_currAbilityCount > 0 && !m_isCasting 
            && _waterBlock.GetComponent<WaterBlock>().GetBlockType() == BlockType.Water)
        {
         
            m_currAbilityCount -= 1;
            m_isCasting = true;

            StartCoroutine(CastIceBlock(_waterBlock));
           
        }
    }

    private IEnumerator PutOutFire(GameObject _fire)
    {
        m_childAnim.SetTrigger("WCWater");
        yield return new WaitForSeconds(1.3f);

        GameObject waterCast = Instantiate(m_waterCastPrefab, m_waterPoint.transform.position, m_waterPoint.transform.rotation);
        FindObjectOfType<AudioManager>().Play("WaterSpray");
        //Play fire dying animation 
        yield return new WaitForSeconds(1.0f);

        _fire.transform.parent.parent.GetComponent<FireBlock>().PutOutFire();
        Destroy(waterCast);
        FindObjectOfType<AudioManager>().Stop("WaterSpray");
        m_isCasting = false;

        yield return null;
    }
    // m_childAnim.SetTrigger("WCFidget");
    private IEnumerator CastIceBlock(GameObject _water)
    {
        m_childAnim.SetTrigger("WCIce");
        yield return new WaitForSeconds(1.5f);

        //Play fire dying animation 
        _water.gameObject.GetComponent<WaterBlock>().CreateIce();

        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<AudioManager>().Play("IceCubeDrop");
        
        GameObject waterSplash = Instantiate(m_waterSplashPrefab, _water.transform.position, Quaternion.identity);
        
       
        yield return new WaitForSeconds(1.5f);
      
        //Make it walkable only after animation is done
        _water.gameObject.GetComponent<WaterBlock>().SetWalkable(true);
        //Spawn ice block in water block. float.
        Destroy(waterSplash);
        m_isCasting = false;
       
         yield return null;
    }

    

}
