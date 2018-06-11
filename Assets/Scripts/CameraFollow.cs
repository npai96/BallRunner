using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject BallSphere;
    public Vector3 Distance;

	// Use this for initialization
	void Start () {
        /* Distance = Camera Pos - Ball Pos */
        Distance = transform.position - BallSphere.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Distance + BallSphere.transform.position;
	}
}
