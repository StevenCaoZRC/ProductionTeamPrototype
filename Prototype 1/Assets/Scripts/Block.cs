using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType { Ground, Grass, Water, Ice, Vine, Fire };

public class Block : MonoBehaviour
{
    public BlockType m_blockType = BlockType.Ground;
    public bool m_isWalkable = true;

    public BlockType GetBlockType() { return m_blockType; }
    public void SetBlockType(BlockType _type) { m_blockType = _type; }

    public bool GetWalkable() { return m_isWalkable; }
    public void SetWalkable(bool _walkable) { m_isWalkable = _walkable; }

    public virtual void Reset()
    {
        m_isWalkable = false;
        m_blockType = BlockType.Ground;
    }

}
