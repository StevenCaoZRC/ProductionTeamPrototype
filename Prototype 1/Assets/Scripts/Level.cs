using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    public string   levelName;
    public bool     waterIsLeading;
    public float    waterMana;
    public float    maxWaterMana;
    public float    forestMana;
    public float    maxForestMana;
}
