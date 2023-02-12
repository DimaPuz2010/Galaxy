using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScreen : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(SceneIDS.levelSceneID);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
