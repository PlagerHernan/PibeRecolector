using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    [SerializeField] GameObject _rocaPrefab;
    [SerializeField] float _timeBetweenThrows; 
    Animator _animator; 

    void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    void Start() 
    {
        InvokeRepeating("Throw", _timeBetweenThrows, _timeBetweenThrows);
    }

    void Throw()
    {
        _animator.SetTrigger("throw");

        Instantiate(_rocaPrefab, transform.position, new Quaternion());
    }
}
