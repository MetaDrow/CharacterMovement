using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private SceneLoadHandler _sceneLoadhandler;

    [Inject]
    private void Construct(SceneLoadHandler sceneLoadhandler)
    {
        _sceneLoadhandler = sceneLoadhandler;
    }

    private void Start()
    {
        _sceneLoadhandler.Initialization();
    }
}