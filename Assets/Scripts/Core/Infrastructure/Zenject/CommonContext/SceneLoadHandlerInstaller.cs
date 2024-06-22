using Zenject;

public class SceneLoadHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SceneLoadHandlerInstall();
    }

    private void SceneLoadHandlerInstall()
    {
        Container.Bind<SceneLoadHandler>().AsSingle();
    }
}
