using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private SceneLoadHandler _sceneLoadHandler;

    [Inject]
    private void Construct(SceneLoadHandler sceneLoadhandler)
    {
        _sceneLoadHandler = sceneLoadhandler;
    }

    private void Start()
    {
        _sceneLoadHandler.Initialization();
    }
}