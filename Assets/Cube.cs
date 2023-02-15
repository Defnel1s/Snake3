using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _cubeSpeed;

    private void Update()
    {
        _cubeSpeed -= 0.002f;
        transform.Translate(x: 0, y: 0, z: _cubeSpeed);
    }
}
