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
        var keyCode = isLeft ? KeyCode.J : KeyCode.K;

        _renderer.enabled = Input.GetKey(keyCode) && Input.GetKey(KeyCode.L);
    }
}