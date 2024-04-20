using System;
using UnityEngine.SceneManagement;

public class SceneLoadHandler
{
    public void Initialization()
    {
        SceneManager.LoadScene(1);
    }
    internal void LoadGamePlay()
    {
        SceneManager.LoadScene(2);
    }
}
