using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoadHandler
{
    private static int _sceneIndex;
    public void Initialization()
    {

        if (_sceneIndex == 0)
        {
            SceneManager.LoadScene(1);
            _sceneIndex = 1;
        }
        CurrentSceneIndexCheck();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGamePlay()
    {
        CurrentSceneIndexCheck();
        SceneManager.LoadScene(2);

    }

    public void LoadNextScene()
    {

    }

    public void CurrentSceneIndexCheck()
    {
       int currnetSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Debug.Log($"Current index = {currnetSceneIndex}");
    }


}
