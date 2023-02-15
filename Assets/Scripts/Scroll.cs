using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float _offset;
    private void Update()
    {
        _offset -= 0.01f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, _offset);
    }
}
