using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    Vector2 playerInitPosition;

    void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerController>().transform.position;
    }
    public void Restart()
    {
        //Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
