﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{   
    Transform _targetWheels;
    Transform _ground;
    Transform [] _wayPoints;

    [SerializeField] float _timeTravel; //min:0 max:1
    [SerializeField] float _velocity; //min:1 max:4
    [SerializeField] float _lifeTime;
    
    bool _stopParabola;

    void Awake() 
    {
        _ground = GameObject.Find("Ground").transform;
        _targetWheels = GameObject.Find("Target Wheels").transform;  
        _wayPoints = GameObject.Find("Bezier").GetComponentsInChildren<Transform>();
    }

    void Start() 
    {
        _wayPoints[0].position = transform.position; //posición del lanzador (donde se instancia roca)
        _wayPoints[1].position = new Vector3(-2f, 10f, 0f); //altura máxima: 10f
        float _xDistance = 5f; //hacer random
        _wayPoints[2].position = new Vector3(_xDistance, _ground.position.y - 1f, 0f); //Y: una unidad por debajo del suelo (para que se detenga al tocarlo)
    }

    void Update()
    {
        if (!_stopParabola)
        {
            Parabola();
        }
    }

    void Parabola()
    {
        _timeTravel = Mathf.Clamp(_timeTravel + 0.005f * _velocity, 0f, 1f);
        transform.position = CalculateBezier(_wayPoints[0].position, _wayPoints[1].position, _wayPoints[2].position, _timeTravel);
    }

    Vector3 CalculateBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3
        p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Ground")
        {
            _stopParabola = true;
            Destroy(gameObject, _lifeTime);
        }

        else if (other.gameObject.name == "Caja Resorte")
        {
            _stopParabola = true; 

            _wayPoints[0].position = transform.position; //empieza desde la última posición de la roca al tocar la caja
            _timeTravel = 0f; //prepara nueva parábola desde cero

            _stopParabola = false;
        }

        else if (other.gameObject.name == "Target Wheels")
        {
            _stopParabola = true;
            Destroy(gameObject);
        }

        else if (other.gameObject.name == "Right Limit")
        {
            _stopParabola = true;
            Destroy(gameObject);
        }
    }
}
