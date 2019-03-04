using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Level m_level;

    static public string m_levelName;
    static public bool m_waterIsLeading;
    static public float m_waterMana;
    static public float m_maxWaterMana;
    static public float m_forestMana;
    static public float m_maxForestMana;
    static public GameObject m_startingPosition;

    public void Start()
    {
        m_levelName =         m_level.levelName;
        m_waterIsLeading =    m_level.waterIsLeading;
        m_waterMana =         m_level.waterMana;
        m_maxWaterMana =      m_level.maxWaterMana;
        m_forestMana =        m_level.forestMana;
        m_maxForestMana =     m_level.maxForestMana;
        m_startingPosition =  m_level.startingPosition;
    }

    static public string GetLvlName()
    {
        return m_levelName;
    }
    static public bool GetLvlWaterLeading()
    {
        return m_waterIsLeading;
    }
    static public float GetLvlWaterMana()
    {
        return m_waterMana;
    }
    static public float GetLvlMaxWaterMana()
    {
        return m_maxWaterMana;
    }
    static public float GetLvlForestMana()
    {
        return m_waterMana;
    }
    static public float GetLvlMaxForestMana()
    {
        return m_maxWaterMana;
    }

    static public Transform GetLvlStartingPos()
    {
        return m_startingPosition.transform;
    }
}
