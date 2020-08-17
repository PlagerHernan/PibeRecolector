using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Game _game;

    [SerializeField] [Range(10, 120)] int _timeLevel;
    float _decimalTimeLevel; 

    private void Start() 
    {
        _decimalTimeLevel = _timeLevel; 
    }

    void Update()
    {
        //Timer en funcionamiento, juego en marcha
        if (_timeLevel > 0)
        {   
            _decimalTimeLevel -= Time.deltaTime; 
            _timeLevel = Mathf.RoundToInt(_decimalTimeLevel);
            GetComponent<Text>().text = "TIME \n" + _timeLevel.ToString();
        }
        //Timer en cero, juego detenido
        else
        {
            if (_game == null)
            {
                _game = FindObjectOfType<Game>();
            }
            _game.FinishLevel();
        }
    }
}
