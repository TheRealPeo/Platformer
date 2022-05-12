using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody theRB;
    public float jumpforce;

    private bool onPlatform = false;
    public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject.Find("Lives").GetComponent<Text>().text = "Lives: " + lives;


        theRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y);

        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpforce);
        }

        // Teleport to near goal, for testing purposes
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    this.transform.position = new Vector3(13, 30, 1);
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Cube"))
        {
            onPlatform = true;
        }

        if (collision.gameObject.name.StartsWith("Y"))
        {
            onPlatform = true;
        }

        if (collision.gameObject.name.StartsWith("X"))
        {
            onPlatform = true;
        }

        if (collision.gameObject.name.StartsWith("DeathZone"))
        {
            GoBackToStart();
        }

        if (collision.gameObject.name.StartsWith("FinishGoal"))
        {
            if (FindObjectOfType<GameManager>().GetCurrentPickup() >= 11)
            {
                SceneManager.LoadScene("WonGame");
            }
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Cube"))
        {
            onPlatform = false;
        }

        if (collision.gameObject.name.StartsWith("Y"))
        {
            onPlatform = false;
        }

        if (collision.gameObject.name.StartsWith("X"))
        {
            onPlatform = false;
        }
    }

    void GoBackToStart()
    {
        if (lives > 1)
        {
            lives--;
            // Move player to start position
            this.transform.position = new Vector3(24.29f, 4.14f, 0.95f);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
