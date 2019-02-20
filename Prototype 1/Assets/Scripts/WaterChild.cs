using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChild : Player
{

    // Start is called before the first frame update
    void Start()
    {
        m_charaElement = Element.Water;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isActive && m_isCasting)
        {
            //Do abilities
        }
    }

    public void WaterSpell()
    {

    }
    public void FreezeSpell()
    {

    }
}
