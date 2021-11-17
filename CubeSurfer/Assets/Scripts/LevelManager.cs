using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        var currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        var nextSceneNumber = currentSceneNumber + 1;
        if (currentSceneNumber < 2)
            SceneManager.LoadScene(nextSceneNumber);
        else
            SceneManager.LoadScene(0);
    }
    public void ReLoadLevel()
    {
        var currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneNumber);
    }
}
