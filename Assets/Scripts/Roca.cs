using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    void Start()
    {
        print("roca start");
        _rigidbody2D.AddForce(new Vector2(1f,1f) * 2f, ForceMode2D.Impulse);
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);    
    }
}
