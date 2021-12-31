using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Vector3 moveVector;
    public Vector3 moveVector2;
    Timer timer;

    public void Start()
    {
        if (!SceneManager.GetActiveScene().name.Contains("Menu"))
        {
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            timer.SetTimerRunning(true);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void LoadKeyboardScene()
    {
        SceneManager.LoadScene("Keyboard");
    }
    public void LoadDiscreteScene()
    {
        SceneManager.LoadScene("DiscreteSmile");
    }
    public void LoadContinuousScene()
    {
        SceneManager.LoadScene("ContinuousSmile");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}