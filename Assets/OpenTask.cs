using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTask : MonoBehaviour
{
    public string taskScene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(taskScene, LoadSceneMode.Single);
    }
}
