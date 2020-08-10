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
        StartCoroutine("ThrowCoroutine");
    }

    IEnumerator ThrowCoroutine()
    {
        _animator.SetTrigger("throw");

        yield return new WaitForSeconds(1f);

        Instantiate(_rocaPrefab, transform.position, new Quaternion());
    }
}
