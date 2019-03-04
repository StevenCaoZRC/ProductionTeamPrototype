﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    static LevelLoader instance = null;

    public Level m_level;

    private void Awake()
    {
        instance = this;
    }
    static public LevelLoader GetInstance()
    {
        return instance;
    }

    public string GetLvlName()
    {
        return m_level.levelName;
    }
    public bool GetLvlWaterLeading()
    {
        return m_level.waterIsLeading;
    }
    public float GetLvlWaterMana()
    {
        return m_level.waterMana;
    }
    public float GetLvlMaxWaterMana()
    {
        return m_level.maxWaterMana;
    }
    public float GetLvlForestMana()
    {
        return m_level.waterMana;
    }
    public float GetLvlMaxForestMana()
    {
        return m_level.maxWaterMana;
    }

    public Transform GetLvlStartingPos()
    {
        return m_level.startingPosition.transform;
    }
}