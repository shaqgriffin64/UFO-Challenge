using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text livesText;
    public Text winText;
    public Text loseText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

            count = 0;
            lives = 3;

            SetCountText ();

            SetLivesText();

            winText.text = "";

            loseText.text = "";
        }

    void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis ("Horizontal");

            float moveVertical = Input.GetAxis ("Vertical");

            Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

            rb2d.AddForce (movement * speed);

            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
    }

    void OnTriggerEnter2D (Collider2D other)
        {
            if (other.gameObject.CompareTag ("PickUp"))
            {
                other.gameObject.SetActive(false);

                count = count + 1;

                SetCountText ();
            }

            if (other.gameObject.CompareTag ("Respawn"))
            {
                other.gameObject.SetActive(false);

                lives = lives - 1;

                SetLivesText();
            }
        }


    void SetCountText ()
        {
            countText.text = "Count: " + count.ToString ();
            

            if (count == 12)
                {
                    transform.position = new Vector3(133, 0, 0);
                }
            if (count == 20)
                {
                    winText.text = "You win! Game Created by Shaquille Griffin";

                    speed = 0;
                }
        }
    void SetLivesText()
        {
            livesText.text = "Lives: " + lives.ToString();

            if (lives == 0)
                {
                    loseText.text = "You lost :(";
                    
                    speed = 0;
                }
        }
}
