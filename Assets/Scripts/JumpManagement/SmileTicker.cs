using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileTicker : MonoBehaviour
{
    SmileReceiver smileReceiver;
    JumpManager jumpManager;
    PlayerMovement playerMovement;
    float counter;
    private bool jumpIsCharging = false;

    // Start is called before the first frame update
    void Start()
    {
        smileReceiver = GameObject.Find("SmileReceiver").GetComponent<SmileReceiver>();
        jumpManager = GameObject.Find("JumpManager").GetComponent<JumpManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        counter = 21.5F;
        InvokeRepeating("CheckForSmile", 0.001F, 0.25F);

    }

    // Update is called once per frame
    void CheckForSmile()
    {

        if (smileReceiver.smileReceived && playerMovement.canJump)
        {
            counter += 0.25F;
            jumpIsCharging = true;
            Debug.Log("Counted Smiles: " + counter);

            if (counter >= 27.5F)
            {
                Debug.Log("MAXIMUM JUMP POWER");
                jumpManager.RequestJump(counter);
                counter = 21.5F;
                jumpIsCharging = false;
            }

            smileReceiver.smileReceived = false;
        }

        else if (jumpIsCharging && playerMovement.canJump)
        { 
        
            jumpManager.RequestJump(counter);    
            Debug.Log("Weak Jump");
            jumpIsCharging = false;
            counter = 21.5F;
            smileReceiver.smileReceived = false;
        }
        else
        {
            smileReceiver.smileReceived = false;
        }

    }

}
