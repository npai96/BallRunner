using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundRestart : MonoBehaviour {

	private void OnTriggerExit()
	{
        SceneManager.LoadScene("MainScene");
	}
}
