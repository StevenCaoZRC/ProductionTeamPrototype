using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    public string       levelName;
    public bool         waterIsLeading;
    public float        waterMana;
    public float        maxWaterMana;
    public float        forestMana;
    public float        maxForestMana;
    public GameObject   startingPosition;

    public void Print()
    {
        Debug.Log("Name: " + levelName);
    }
}
