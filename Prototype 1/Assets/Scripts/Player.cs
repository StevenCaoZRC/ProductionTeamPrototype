using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Variables
    public int abilityCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        abilityCount = 0;
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
