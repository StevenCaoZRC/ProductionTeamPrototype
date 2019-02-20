using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Variables

    public enum Element {NONE, FIRE, WATER};
    public int abilityCount = 3;

    public Element charaElement;

    // Start is called before the first frame update
    void Start()
    {
        abilityCount = 0;
        charaElement = Element.FIRE;
    }

    public void SetAbilityCount(int newAmount)
    {
        abilityCount = newAmount;
    }

    public int GetAbilityCount()
    {
        return abilityCount;
    }
}
