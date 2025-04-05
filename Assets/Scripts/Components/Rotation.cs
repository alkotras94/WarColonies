using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation
{
    private Transform _transformObject;

    public Rotation(Transform transform)
    {
        _transformObject = transform;
    }

    public void Rotate(Vector2 transform)
    {
        if (_transformObject.position.x > transform.x)
        {
            _transformObject.rotation = Quaternion.Euler(0, 180, 0); //Turn left
        }
        if (_transformObject.position.x < transform.x)
        {
            _transformObject.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
