﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finsih : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Happs");
        if (other.tag == "Player")
        {
            
            SceneManager.LoadScene("TutorialScene");
        }
    }
}
