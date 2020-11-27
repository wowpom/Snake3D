using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void onPlayHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void onExitHandler()
    {
        Application.Quit();
    }
    public void onMenuHandler()
    {
        SceneManager.LoadScene(0);
    }
}
