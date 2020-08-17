using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float _lifeTime;

    void Start() 
    {
        Destroy(gameObject, _lifeTime);    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            //
        }    
    }
}
