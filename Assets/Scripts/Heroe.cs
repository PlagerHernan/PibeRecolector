using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    [SerializeField] Transform _rightLimit;
    [SerializeField] Transform _leftLimit;
    float _groundPosition;

    [SerializeField] float _velocity;
    float _xMovement;
    Animator _animator;

    void Awake() 
    {
        _groundPosition = GameObject.Find("Ground").transform.position.y + 0.5f; //un poco más arriba del suelo
        
        _animator = GetComponent<Animator>();  
    } 

    void Start() 
    {
        transform.position = new Vector3(8f, _groundPosition, 0f);
    }

    void Update()
    {
        Movement();
        Animations();
    }

    void Movement()
    {
        //movimiento en eje X, a la velocidad asignada en inspector
        _xMovement = Input.GetAxisRaw("Horizontal") * _velocity;
        transform.position += new Vector3(_xMovement, 0f, 0f) * Time.deltaTime;

        //si la posición excede los limites, vuelve a posición
        if (transform.position.x > _rightLimit.position.x)
        {
            transform.position = new Vector3(_rightLimit.position.x, _groundPosition, 0f);
        }
        if (transform.position.x < _leftLimit.position.x)
        {
            transform.position = new Vector3(_leftLimit.position.x, _groundPosition, 0f);
        }
    }

    void Animations()
    {
        //si está detenido
        if (_xMovement == 0)
        {
            _animator.SetBool("moving", false);
        }
        //si está en movimiento
        else
        {
            _animator.SetBool("moving", true);

            if (_xMovement < 0)
            {
                //mira hacia la izquierda
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            else
            {
                //mira hacia la derecha
                transform.localScale = new Vector3(1f,1f,1f);
            }
        }
    }
}
