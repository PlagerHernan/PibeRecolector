using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{   
    Transform _targetWheels;
    Transform _ground;
    [SerializeField] float _timeTravel; //min:0 max:1
    [SerializeField] float _velocity; //min:1 max:4
    Transform _wayPoint0, _wayPoint1, _wayPoint2;

    //variable altura max
    
    [SerializeField] float _lifeTime;
    Vector3 _initialPosition;
    Vector3 _startRebound;
    Vector3 _endParabola;
    Vector3 _endRebound;
    float _animation;
    float _animRebound;
    bool _stopParabola;
    bool _touchedBox;

    void Awake() 
    {
        _ground = GameObject.Find("Ground").transform;
        _targetWheels = GameObject.Find("Target Wheels").transform;   

        _wayPoint0 = GameObject.Find("WayPoint 0").transform;
        _wayPoint1 = GameObject.Find("WayPoint 1").transform;
        _wayPoint2 = GameObject.Find("WayPoint 2").transform; 
    }

    void Start() 
    {
        _wayPoint0.position = transform.position;
        _wayPoint1.position = new Vector3(-2f, 8f, 0f);
        _wayPoint2.position = new Vector3(5f, _ground.position.y - 1f, 0f); //Y: una unidad por debajo del suelo (para que se detenga al tocarlo)

        /* _initialPosition = transform.position;   

        _endParabola = new Vector3(7f,-6f, 0f); //Y: una unidad por debajo del suelo (para que se detenga al tocarlo)
        _endRebound = new Vector3(11f,-6f, 0f); */
    }

    void Update()
    {
        //si no tocó el suelo ni la caja, realiza 1ra parábola
        if (!_stopParabola)
        {
            //FirstParabola();
            _timeTravel = Mathf.Clamp(_timeTravel + 0.005f * _velocity, 0f, 1f);
            transform.position = CalculateBezier(_wayPoint0.position, _wayPoint1.position, _wayPoint2.position, _timeTravel);
        }
        //si tocó la caja resorte, realiza rebote
        else if (_touchedBox)
        {
            //Rebound();
        }
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

    /* void FirstParabola()
    {
        _animation += Time.deltaTime;
        _animation = _animation % 2.5f;

        transform.position = MathParabola.Parabola(_initialPosition, _endParabola, 6.5f, _animation/2.5f);
    }

    void Rebound()
    {
        _animRebound += Time.deltaTime;
        _animRebound = _animRebound % 2.5f;

        transform.position = MathParabola.Parabola(_startRebound, _targetWheels.transform.position, 6.5f, _animRebound/2.5f);
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

            _startRebound = transform.position;
            _touchedBox = true;
        }

        else if (other.gameObject.name == "Target Wheels")
        {
            _stopParabola = true;

            Destroy(gameObject);
        }
    }

    void DestroyObject() 
    {
        Destroy(gameObject);    
    }
}
