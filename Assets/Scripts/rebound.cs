using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebound : MonoBehaviour
{
    [SerializeField] float _bounceSpeed = 1.0f;
    [SerializeField] float _bounceAmount = 2.0f;
    float _yPosition;

    /* void Start () 
    {
        float t = 0.0f;

        while (t < 1.0) 
        {
            t += Time.deltaTime * _bounceSpeed;
            _yPosition = Bounce(t) * _bounceAmount;
            transform.position = new Vector3(0f, _yPosition, 0f);
        }
    } */

    void Update () 
    {
        _yPosition = Bounce((Time.time * _bounceSpeed)%1) * _bounceAmount;
        transform.position = new Vector3(0f, _yPosition, 0f);
    } 


    float Bounce (float t)
    {
        return Mathf.Sin(Mathf.Clamp01(t) * Mathf.PI);
    }
}
