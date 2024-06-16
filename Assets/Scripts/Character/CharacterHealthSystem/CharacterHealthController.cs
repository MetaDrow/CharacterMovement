using UniRx;
using UnityEngine;
using Platformer.Character;

namespace HealthSystem
{
    public class CharacterHealthController : MonoBehaviour
    {
        private CompositeDisposable _disposable = new CompositeDisposable();
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private CharacterHealthView _healthView;
        private CharacterHealthModel _healthModel;

        private void Start()
        {
            _healthModel = new CharacterHealthModel(_healthView, _characterData, _disposable);
            _healthModel.InitializationCharacterHealthView();
            _healthModel.ChangeCharacterHealthView();
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}