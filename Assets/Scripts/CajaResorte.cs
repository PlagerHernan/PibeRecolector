using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaResorte : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 1.5f)] float _verticalBounceFactor;
    public float VerticalBounceFactor { get => _verticalBounceFactor; }
}
