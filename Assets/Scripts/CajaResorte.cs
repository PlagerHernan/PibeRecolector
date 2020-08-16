using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaResorte : MonoBehaviour
{
    [SerializeField] float _verticalBounceFactor;
    public float VerticalBounceFactor { get => _verticalBounceFactor; }
}
