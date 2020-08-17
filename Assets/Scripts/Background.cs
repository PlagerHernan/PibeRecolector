using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] float _parallaxSpeed; //0.01f 

    RawImage _rawImage;

    void Awake() 
    {
        _rawImage = GetComponent<RawImage>();    
    } 

    void Update() 
    {
        //efecto parallax
        _rawImage.uvRect = new Rect(_mainCamera.transform.position.x * _parallaxSpeed, 0f, 1f, 1f);        
    }
}
