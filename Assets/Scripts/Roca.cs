using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{   
    Game _game;
    CajaResorte _cajaResorte;
    [SerializeField] GameObject _prefabBezier; GameObject _bezier; Transform [] _wayPoints;
    Transform _targetWheels;
    Transform _ground;

    [SerializeField] [Range(1f, 4f)] float _velocity; 
    [SerializeField] [Range(1f, 4f)] float _lifeTime;
    
    bool _stopParabola;
    float _timeTravel;

    void Awake() 
    {
        _game = FindObjectOfType<Game>();
        _cajaResorte = FindObjectOfType<CajaResorte>();
        _targetWheels = GameObject.Find("Target Wheels").transform;  
        _ground = GameObject.Find("Ground").transform;
    }

    void Start() 
    {
        PrepareParabola();
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
        _timeTravel = Mathf.Clamp(_timeTravel + 0.3f * _velocity * Time.deltaTime, 0f, 1f); //0: inicio trayectoria //1: fin trayectoria 
        transform.position = CalculateBezier(_wayPoints[0].position, _wayPoints[1].position, _wayPoints[2].position, _timeTravel);
    }

    Vector3 CalculateBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        //Fórmula curva cuadrática de Bézier
        Vector3 bezier = (1-t) * (1-t) * p0 + 2*t * (1-t) * p1 + t*t * p2;

        return bezier;
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
            _game.AddStone();

            Destroy(gameObject);
            Destroy(_bezier);
        }
    }

    //posiciona wayPoints para primer parábola
    void PrepareParabola()
    {
        _bezier = GameObject.Instantiate(_prefabBezier);
        _wayPoints = _bezier.GetComponentsInChildren<Transform>();

        float _xDistance = Random.Range(5f, 15f); 
        float _yDistance = Random.Range(3f, 15f); 
        
        _wayPoints[0].position = transform.position; //posición del lanzador (donde se instancia roca)
        _wayPoints[1].position = new Vector3(_xDistance/2, 10f, 0f); //X: a mitad de camino entre posición inicial y final
        _wayPoints[2].position = new Vector3(_xDistance, _ground.position.y - 1f, 0f); //Y: una unidad por debajo del suelo (para que se detenga al tocarlo)
    }

    //reposiciona wayPoints para próxima parábola (rebote)
    void PrepareRebound()
    {
        //empieza desde la última posición de la roca al tocar la caja
        _wayPoints[0].position = transform.position;

        //distancia que le queda hasta el target
        float distance = _targetWheels.position.x - _wayPoints[2].position.x;
        //Último rebote 
        //si se pasa del target o le falta muy poco para llegar, va hacia target (un poco más a la derecha, por el hueco)
        if (_wayPoints[2].position.x > _targetWheels.position.x || distance < 1f)
        {
            _wayPoints[2].position = new Vector3(_targetWheels.position.x + 0.7f, _targetWheels.position.y, 0f);
        }
        //No es último rebote 
        else
        {
            //altura depende del factor de rebote vertical de la caja
            _wayPoints[1].position = new Vector3(_wayPoints[1].position.x, _wayPoints[1].position.y * _cajaResorte.VerticalBounceFactor, 0f);
        }

        //resetea tiempo de trayectoria (nueva parábola desde cero)
        _timeTravel = 0f; 
    }
}
