using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    //cache SceneLoader
    private SceneLoader mySceneLoader;

    private void Awake()
    {
        mySceneLoader = FindObjectOfType<SceneLoader>();
    }

    //Win Trigger
    private void OnTriggerEnter(Collider other)
    {
        mySceneLoader.LoadNextLevel();
    }


   
}

