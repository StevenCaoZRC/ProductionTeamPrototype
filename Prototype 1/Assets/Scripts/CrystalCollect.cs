using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalCollect : MonoBehaviour
{
    public GameObject m_notCollected;
    public GameObject m_collected;
    public TextMeshProUGUI m_crystalText;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Reset()
    {
        m_notCollected.SetActive(true);
        m_collected.SetActive(false);
        m_crystalText.gameObject.SetActive(true);
        transform.position = LevelLoader.GetInstance().GetCrystalStartingPos().position;
        transform.rotation = LevelLoader.GetInstance().GetCrystalStartingPos().rotation;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            m_collected.SetActive(true);
            m_notCollected.SetActive(false);
            gameObject.SetActive(false);
            m_crystalText.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().PlayOnce("CrystalCollect");
        }

    }
}