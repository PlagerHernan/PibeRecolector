using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    Rigidbody2D _rigidbody2D;

    void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    void Start()
    {
        _rigidbody2D.AddForce(new Vector2(1f,1f) * 2f, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //si cae al suelo, se destruye a los X segundos
        if (other.gameObject.name == "Ground")
        {
            Invoke("DestroyObject", _lifeTime);   
        }
    }

    void DestroyObject() 
    {
        Destroy(gameObject);    
    }
}
