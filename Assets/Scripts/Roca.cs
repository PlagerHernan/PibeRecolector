using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    bool _grounded;
    Vector3 _initialPosition;
    Vector3 _finalPosition;
    float _animation;

    void Start() 
    {
        _initialPosition = transform.position;   
        _finalPosition = new Vector3(11f,-6f, 0f); //Y: una unidad por debajo del suelo (para que se detenga al tocarlo)
    }

    void Update()
    {
        //si aún no tocó el suelo, realiza parábola
        if (!_grounded)
        {
            Parabola();
        }
    }

    void Parabola()
    {
        _animation += Time.deltaTime;
        _animation = _animation % 2.5f;

        transform.position = MathParabola.Parabola(_initialPosition, _finalPosition, 6.5f, _animation/2.5f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //si toca el suelo, se detiene la parábola y se destruye la roca a los X segundos
        if (other.gameObject.name == "Ground")
        {
            _grounded = true;
            
            Invoke("DestroyObject", _lifeTime);   
        }
    }

    void DestroyObject() 
    {
        Destroy(gameObject);    
    }
}
