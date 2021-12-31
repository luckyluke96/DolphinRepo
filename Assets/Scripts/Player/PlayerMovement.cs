using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public bool canJump = true;

    // Max JF = 27.5F
    public float jumpForce = 21.5F;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().name == "DiscreteSmile")
        {
            jumpForce = 27.5F;
        }
        else if (SceneManager.GetActiveScene().name == "ContinuousSmile")
        {
            jumpForce = 21.5F;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GroundWall")
        {
            canJump = true;
            Debug.Log("canJump ist true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GroundWall")
        {
            canJump = false;
            Debug.Log("canJump ist false");
        }
    }

    public void Jump(float force)
    {
        rigidBody.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }
}
