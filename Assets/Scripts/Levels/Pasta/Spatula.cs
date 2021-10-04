using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public bool isLeft;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        var lidOpen = FindObjectOfType<Levels.Pasta.SpaghettiLevel>().lidOpen;

        var keyCode = isLeft ? KeyCode.LeftArrow : KeyCode.RightArrow;

        _renderer.enabled = Input.GetKey(keyCode) && lidOpen;// && Input.GetKey(KeyCode.K);
    }
}