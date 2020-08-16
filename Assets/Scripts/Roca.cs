using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{   
    [SerializeField] GameObject _prefabBezier; GameObject _bezier; Transform [] _wayPoints;
    Transform _targetWheels;
    Transform _ground;

    [SerializeField] float _timeTravel; //min:0 max:1
    [SerializeField] float _velocity = 3f; //min:1 max:4
    [SerializeField] float _lifeTime;
    
    bool _stopParabola;

    void Awake() 
    {
        _ground = GameObject.Find("Ground").transform;
        _targetWheels = GameObject.Find("Target Wheels").transform;  
    }

    void Start() 
    {
        _bezier = GameObject.Instantiate(_prefabBezier);
        _wayPoints = _bezier.GetComponentsInChildren<Transform>();

        float _xDistance = Random.Range(5f, 15f); //hacer random, min:4
        float _yDistance = Random.Range(3f, 15f); //hacer random, max:10
        
        _wayPoints[0].position = transform.position; //posición del lanzador (donde se instancia roca)
        _wayPoints[1].position = new Vector3(_xDistance/2, 10f, 0f); //X: a mitad de camino entre posición inicial y final
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
        _timeTravel = Mathf.Clamp(_timeTravel + 0.3f * _velocity * Time.deltaTime, 0f, 1f);
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
            Destroy(_bezier);
        }

        else if (other.gameObject.name == "Caja Resorte")
        {
            _stopParabola = true; 

            PrepareRebound();

            _stopParabola = false;
        }

        else if (other.gameObject.name == "Target Wheels")
        {
            Destroy(gameObject);
            Destroy(_bezier);
        }

        else if (other.gameObject.name == "Right Limit")
        {
            Destroy(gameObject);
            Destroy(_bezier);
        }
    }

    //reposiciona wayPoints para próxima parábola (rebote)
    void PrepareRebound()
    {
        _wayPoints[0].position = transform.position; //empieza desde la última posición de la roca al tocar la caja

        float distance = _targetWheels.position.x - _wayPoints[2].position.x;
        //si va a pasarse del target o le va a faltar muy poco para llegar, va hacia target (un poco más a la derecha, por el hueco)
        if (_wayPoints[2].position.x > _targetWheels.position.x || distance < 1f)
        {
            _wayPoints[2].position = new Vector3(_targetWheels.position.x + 0.7f, _targetWheels.position.y, 0f);
        }

        _timeTravel = 0f; //resetea tiempo de trayectoria (nueva parábola desde cero)
    }
}
