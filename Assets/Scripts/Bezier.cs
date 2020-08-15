using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public Transform w1, w2, w3;
    public GameObject ball;
    public float timeTravel;
    [SerializeField] float _velocity; //min:1 max:4
    public bool floor;
    Transform[] wayPoints, wayPointBounds;

    private void Update()
    {
        timeTravel = Mathf.Clamp(timeTravel + 0.005f * _velocity, 0f, 1f);
        ball.transform.position = CalculateCuadraticBezierPoint(w1.position, w2.position, w3.position, timeTravel);
    }

    public Vector3 CalculateCuadraticBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3
        p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }
}