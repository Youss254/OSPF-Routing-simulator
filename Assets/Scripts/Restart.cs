using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{

    public void RestartGame()
    {
        cableCreation.couples.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}