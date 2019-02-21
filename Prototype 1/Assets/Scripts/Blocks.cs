using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType { Ground, Grass, Water };
public class Blocks : ScriptableObject
{
    public BlockType blockType;
    public bool isWalkable;


}
