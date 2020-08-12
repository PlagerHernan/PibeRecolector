using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testparabola : MonoBehaviour
{
    Vector3 _initialPosition;
    float _animation;

    void Start() 
    {
        _initialPosition = transform.position;    
    }

    void Update()
    {
        Throw();
    }

    void Throw()
    {
        _animation += Time.deltaTime;
        _animation = _animation % 2.5f;

        transform.position = MathParabola.Parabola(_initialPosition, new Vector3(11f,-4f, 0f), 6.5f, _animation/2.5f);
    }
}
