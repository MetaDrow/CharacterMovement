using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private GameObject _mainMenu;
    public override void InstallBindings()
    {
        MainMenuInstall();
    }

    private void MainMenuInstall()
    {
        MainMenuPanel mainMenu = Container.InstantiatePrefabForComponent<MainMenuPanel>(_mainMenu);

        Container.Bind<MainMenuPanel>().
        FromInstance(mainMenu).
        AsSingle();
    }
}
