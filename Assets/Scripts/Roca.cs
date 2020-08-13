﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    Vector3 _initialPosition;
    Vector3 _startRebound;
    Vector3 _endParabola;
    Vector3 _endRebound;
    float _animation;
    bool _stopParabola;
    bool _touchedBox;

    void Start() 
    {
        _initialPosition = transform.position;   

        _endParabola = new Vector3(7f,-6f, 0f); //Y: una unidad por debajo del suelo (para que se detenga al tocarlo)
        _endRebound = new Vector3(11f,-6f, 0f);
    }

    void Update()
    {
        //si no tocó el suelo ni la caja, realiza 1ra parábola
        if (!_stopParabola)
        {
            FirstParabola();
        }
        //si tocó la caja resorte, realiza rebote
        else if (_touchedBox)
        {
            //Rebound();
        }
    }

    void FirstParabola()
    {
        _animation += Time.deltaTime;
        _animation = _animation % 2.5f;

        transform.position = MathParabola.Parabola(_initialPosition, _endParabola, 6.5f, _animation/2.5f);
    }

    /* void Rebound()
    {
        _animation += Time.deltaTime;
        _animation = _animation % 2.5f;

        transform.position = MathParabola.Parabola(_startRebound, _endRebound, 6.5f, _animation/2.5f);
    } */

    void OnTriggerEnter2D(Collider2D other) 
    {
        //si toca el suelo, se detiene la parábola y se destruye la roca a los X segundos
        if (other.gameObject.name == "Ground")
        {
            _stopParabola = true;

            Invoke("DestroyObject", _lifeTime);   
        }

        else if (other.gameObject.name == "Caja Resorte")
        {
            _stopParabola = true;

            /* _startRebound = transform.position;
            _touchedBox = true; */
        }
    }

    void DestroyObject() 
    {
        Destroy(gameObject);    
    }
}
