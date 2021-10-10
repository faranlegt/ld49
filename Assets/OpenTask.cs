using System;
using System.Collections;
using System.Collections.Generic;
using Core.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTask : MonoBehaviour
{
    public Level level;

    private void OnMouseDown()
    {
        if (level)
        {
            LevelLoader.LevelToLoad = level;
            SceneManager.LoadScene("LevelBase", LoadSceneMode.Single);
        }
        else
        {
            
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }
}
