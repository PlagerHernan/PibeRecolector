using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    [SerializeField] float _velocity;
    float _xMovement;

    void Update()
    {
        _xMovement = Input.GetAxisRaw("Horizontal") * _velocity;
        transform.position += new Vector3(_xMovement, 0f, 0f) * Time.deltaTime;
    }
}
