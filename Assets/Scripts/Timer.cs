using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int _timeLevel;
    float _decimalTimeLevel; 

    private void Start() 
    {
        _decimalTimeLevel = _timeLevel; 
    }

    void Update()
    {
        if (_timeLevel > 0)
        {   
            _decimalTimeLevel -= Time.deltaTime; 
            _timeLevel = Mathf.RoundToInt(_decimalTimeLevel);
            GetComponent<Text>().text = "TIME \n" + _timeLevel.ToString();
        }
    }
}
