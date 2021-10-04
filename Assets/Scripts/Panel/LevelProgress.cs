using System.Collections;
using System.Collections.Generic;
using Levels;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    private Level _level;

    public void Start()
    {
        _level = FindObjectOfType<Level>();
    }

    public void Update()
    {
        var p = transform.position;
        p.x = 7 * _level.levelGoing / _level.fullLevelTime;
        transform.position = p;
    }
}
