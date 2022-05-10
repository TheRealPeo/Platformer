using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody theRB;
    public float jumpforce;

    private bool onPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y);

        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpforce);
        }
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
        // Move player to start position
        this.transform.position = new Vector3(24.29f, 4.14f, 0.95f);
    }
}
