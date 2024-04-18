using Zenject;

public class BootstrapInstaller : MonoInstaller
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
