using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmileTicker : MonoBehaviour
{
    SmileReceiver smileReceiver;
    JumpManager jumpManager;
    PlayerMovement playerMovement;
    float counter;
    private bool jumpIsCharging = false;
    Slider jumpbar;

    // Start is called before the first frame update
    void Start()
    {
        smileReceiver = GameObject.Find("SmileReceiver").GetComponent<SmileReceiver>();
        jumpManager = GameObject.Find("JumpManager").GetComponent<JumpManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        jumpbar = GameObject.Find("Jumpbar").GetComponent<Slider>();


        counter = 21.5F;
        InvokeRepeating("CheckForSmile", 0.001F, 0.25F);

    }

    void CheckForSmile()
    {

        if (counter < 27.5)
        {
            if (smileReceiver.smileReceived && playerMovement.canJump)
            {
                counter += 0.25F;
                jumpIsCharging = true;
                Debug.Log("Counted Smiles: " + counter);
                jumpbar.value = jumpbar.value + 0.25F;
            }
            else if (jumpIsCharging && playerMovement.canJump)
            {
                jumpManager.RequestJump(counter);
                Debug.Log("Weak Jump");
                jumpIsCharging = false;
                counter = 21.5F;
                jumpbar.value = 0;
            }
            smileReceiver.smileReceived = false;
        }

        else if (counter >= 27.5)
        {
            if (smileReceiver.smileReceived && playerMovement.canJump)
            {
                jumpIsCharging = true;
                Debug.Log("Counted Smiles: " + counter);
            }
            else if (jumpIsCharging && playerMovement.canJump)
            {
                jumpManager.RequestJump(27.5F);
                Debug.Log("Max Jump");
                jumpIsCharging = false;
                counter = 21.5F;
                jumpbar.value = 0;
            }
            smileReceiver.smileReceived = false;
        }
    }

}