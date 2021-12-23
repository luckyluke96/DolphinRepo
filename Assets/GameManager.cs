using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Vector3 moveVector;
    public Vector3 moveVector2;

    public void EndGame()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().name == "MenuDiscreteSmile")
        {
            SceneManager.LoadScene("DiscreteSmile");
        }
        if (SceneManager.GetActiveScene().name == "MenuCountinuousSmile")
        {
            SceneManager.LoadScene("ContinuousSmile");
        }
        if (SceneManager.GetActiveScene().name == "MenuKeyboard")
        {
            SceneManager.LoadScene("Keyboard");
        }
    }
}