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
        Debug.Log("Putting out fire: " + _fire.name);
        //Play animation 
        m_isCasting = true;
        Destroy(_fire, 2.0f);
    }
    public override void SpellTwo(GameObject _waterBlock)
    {

    }
}
