using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestChild : Player
{
    // Start is called before the first frame update
    void Awake()
    {
        m_charaElement = Element.Forest;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void SpellOne(GameObject _fire)
    {
        
    }

    public override void SpellTwo(GameObject _waterBlock)
    {

    }
}
