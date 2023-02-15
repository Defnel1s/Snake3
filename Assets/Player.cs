using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _moveRight, _moveLeft;

    public void MoveR(bool moveRight)
    {
        _moveRight = moveRight;
    }
    public void MoveL(bool moveLeft)
    {
        _moveLeft = moveLeft;
    }
    private void Update()
    {
        if (_moveRight) transform.Translate(x: 0.03f, y: 0, z: 0);
        if (_moveLeft) transform.Translate(x: -0.03f, y: 0, z: 0);
    }
}
