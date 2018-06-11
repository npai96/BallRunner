using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour {

    Vector3 TurnCoins;
	// Update is called once per frame
	void Update () {
        TurnCoins = new Vector3(0, 0, 45);

        transform.Rotate(TurnCoins * Time.deltaTime);
	}
}
