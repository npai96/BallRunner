using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour {

    Rigidbody rb;
    public int BallMovementSpeed = 20;
    public int BallJumpSpeed = 30;
    private bool isOnPlatform = true;
    private bool canDoubleJump = true;
    private int CoinCounter = 6;
    public Text CoinText;
    public AudioSource ScoreSource;
    public AudioClip Score;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        CoinCounter = 6;
	}
	
	// Update is called once per frame
	void Update () {
        /* Movement in Horizontal & Vertical directions */
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        /* Vector3 ("movement" objects) */
        Vector3 BallMovement = new Vector3(HorizontalMove, 0.0f, VerticalMove);
        rb.AddForce(BallMovement * BallMovementSpeed);

        /* Jump + Double Jump conditions */
        if ((Input.GetKey(KeyCode.Space)) && (isOnPlatform)) {
            Jump();
            isOnPlatform = false; /* Restore */
        } 
        else if ((!isOnPlatform) && (canDoubleJump)) {
            Jump();
            canDoubleJump = false;
        }
       
	}

    /* Collisions with elevated platform */
    private void OnCollisionStay() {
        isOnPlatform = true;
        canDoubleJump = true;
    }

    /* Generic jump method */
    private void Jump() 
    {
        Vector3 BallJump = new Vector3(0.0f, 6.0f, 0.0f);
        rb.AddForce(BallJump * BallJumpSpeed);
    }

    /* Collect coins */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinsTag")) {
            other.gameObject.SetActive(false);
            CoinCounter--;
            CoinText.text = "COINS: " + CoinCounter;
            ScoreSource.PlayOneShot(Score);

            if (CoinCounter == 6) {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}