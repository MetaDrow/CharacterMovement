using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private GameObject _camera;

    public override void InstallBindings()
    {
        HeroPrefabInstall();
        HeroCameraInstall();
    }

    private void HeroPrefabInstall()
    {
        Character character = Container.InstantiatePrefabForComponent<Character>(_character, _characterTransform.position, Quaternion.Euler(0,90,0), null);

        Container.Bind<Character>().
        FromInstance(character).
        AsSingle();
    }

    private void HeroCameraInstall()
    {
        CharacterCamera camera  = Container.InstantiatePrefabForComponent<CharacterCamera>(_camera, _characterTransform.position, Quaternion.identity, null);

        Container.Bind<CharacterCamera>().
        FromInstance(camera).
        AsSingle();
    }
}
