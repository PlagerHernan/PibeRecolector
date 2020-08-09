using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    [SerializeField] float _velocity;
    float _xMovement;
    Animator _animator;

    void Awake() 
    {
        _animator = GetComponent<Animator>();  
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
