using UnityEngine.SceneManagement;

public class SceneLoadHandler
{
    public void Initialization()
    {
        LoadMainMenuScene();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene(2);
    }
}
