using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChild : Player
{

    // Start is called before the first frame update
    void Awake()
    {
        m_charaElement = Element.Water;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpellOne(GameObject _fire)
    {
        //put out fire
        StartCoroutine(DestroyFire(_fire));
    }
    public override void SpellTwo(GameObject _waterBlock)
    {
        //Create ice block in river
        m_isCasting = true;


    }

    private IEnumerator DestroyFire(GameObject _fire)
    {
        m_isCasting = true;

        Debug.Log("Casting: " + m_isCasting);
        //Play animation 
        yield return new WaitForSeconds(5);
        Destroy(_fire.transform.parent.gameObject);

        m_isCasting = false;
        Debug.Log("Casting: " + m_isCasting);

        yield return null;
    }
}
