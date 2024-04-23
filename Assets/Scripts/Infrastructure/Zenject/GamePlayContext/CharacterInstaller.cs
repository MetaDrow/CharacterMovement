using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private GameObject _characterCamera;

    public override void InstallBindings()
    {
        CharacterPrefabInstall();
        CharacterCameraInstall();
    }

    private void CharacterPrefabInstall()
    {
        Character character = Container.InstantiatePrefabForComponent<Character>(_character, _characterTransform.position, Quaternion.Euler(0,90,0), null);

        Container.Bind<Character>().
        FromInstance(character).
        AsSingle();
    }

    private void CharacterCameraInstall()
    {
        CharacterCamera camera  = Container.InstantiatePrefabForComponent<CharacterCamera>(_characterCamera, _characterTransform.position, Quaternion.identity, null);

        Container.Bind<CharacterCamera>().
        FromInstance(camera).
        AsSingle();
    }
}
