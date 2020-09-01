using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    [SerializeField] GameObject _rocaPrefab;
    [SerializeField] [Range(1f, 6f)] float _timeBetweenThrows; 
    Animator _animator; 

    void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    void Start() 
    {
        InvokeRepeating("Throw", 1f, _timeBetweenThrows);
    }

    void Throw()
    {
        StartCoroutine(ThrowCoroutine());
    }

    IEnumerator ThrowCoroutine()
    {
        _animator.SetTrigger("throw");

        yield return new WaitForSeconds(0.4f);

        Instantiate(_rocaPrefab, transform.position, new Quaternion());
    }
}
