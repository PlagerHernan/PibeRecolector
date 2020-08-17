using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Game _game;

    [SerializeField] [Range(3f, 7f)] float _lifeTime;

    void Start() 
    {
        Destroy(gameObject, _lifeTime);    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if (_game == null)
            {
                _game = FindObjectOfType<Game>();
            }
            _game.AddCoin();
            Destroy(gameObject);
        }    
    }
}
