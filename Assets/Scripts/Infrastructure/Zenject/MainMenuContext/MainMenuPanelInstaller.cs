using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuPanelInstaller : MonoInstaller
{
    [SerializeField] private GameObject _abstractPanel;

    public override void InstallBindings()
    {
        MainMenuInstall();
    }

    private void MainMenuInstall()
    {
       MainMenuPanel mainMenu = Container.InstantiatePrefabForComponent<MainMenuPanel>(_abstractPanel);

        Container.Bind<MainMenuPanel>().
        FromInstance(mainMenu).
        AsSingle();
    }
}
