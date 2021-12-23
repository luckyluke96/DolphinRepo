using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudConstantMove : MonoBehaviour
{
    GameManager gameManager;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();

        anim = GetComponent<Animator>();
      }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gameManager.moveVector * gameManager.moveSpeed * Time.deltaTime);
        if (transform.position.x <= -9)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collision");
        if(collision.gameObject.name == "Player")
        {
            anim.Play("wolkeverpufft-pop");
            Debug.Log("play anim");
            Destroy(gameObject);
        } else if (collision.gameObject.name == "Sun") {
            
            Destroy(gameObject);
        }
    }

}