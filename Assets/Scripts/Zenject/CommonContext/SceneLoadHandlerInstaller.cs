using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneLoadHandlerInstaller : MonoInstaller
{
    //[SerializeField] private SceneLoadHandler _loadHandler;

    public override void InstallBindings()
    {
        Container.Bind<SceneLoadHandler>().AsSingle();
    }

    
}
