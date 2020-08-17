using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject _prefabCoin;

    [SerializeField] int _quantityOfStonesForCoin;

    Text _stonesText;
    int _stonesCount;

    Transform _ground;
    Transform _rightLimit; 
    Transform _leftLimit; 
    Vector3 _coinPosition; 

    void Awake() 
    {
        _stonesText = GameObject.Find("Stones Count").GetComponentInChildren<Text>();

        _ground = GameObject.Find("Ground").transform;
        _rightLimit = GameObject.Find("Right Limit").transform;
        _leftLimit = GameObject.Find("Left Limit").transform;
    }

    public void AddStone()
    {
        _stonesCount++;
        _stonesText.text = "x " + _stonesCount.ToString("00"); 

        if (_stonesCount == _quantityOfStonesForCoin)
        {
            GetCoinPosition();
            Instantiate(_prefabCoin, _coinPosition, new Quaternion()); 
            _stonesCount = 0;
        }
    }

    void GetCoinPosition()
    {
        //posición X random entre limites del área de juego
        float xPosition = Random.Range(_leftLimit.position.x, _rightLimit.position.x); 
        //posición Y random cercana a ground 
        float yPosition = Random.Range(_ground.position.y -1f, _ground.position.y +1f); 

        _coinPosition = new Vector3(xPosition, yPosition);  
    }
}
