using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    Text _stonesText;

    int _stonesCount;

    void Awake() 
    {
        _stonesText = GameObject.Find("Stones Count").GetComponentInChildren<Text>();
    }

    public void AddStone()
    {
        _stonesCount++;
        _stonesText.text = "x " + _stonesCount.ToString("00"); 
    }
}
