using UniRx;
using Platformer.Character;

namespace HealthSystem
{
    public class CharacterHealthModel 
    {
        internal protected CharacterData _characterData;
        private CharacterHealthView _healthView;
        private CompositeDisposable _disposable;

        public CharacterHealthModel(CharacterHealthView healthView, CharacterData characterData, CompositeDisposable disposable)
        {
            _healthView = healthView;
            _characterData = characterData;
            _disposable = disposable;
        }

        internal void InitializationCharacterHealthView()
        {

            _healthView._slider.maxValue = 100;
            _healthView._slider.value = _characterData.HealthReadOnly.Value;
            _healthView._textMeshProUGUI.text = _characterData.HealthReadOnly.Value.ToString();
        }

        internal protected void CharacterInitHealthValue() => _characterData.Health.Value = 100;

        public void ChangeCharacterHealthView()
        {
            _characterData.HealthReadOnly.Subscribe(value =>
            {
                _healthView._textMeshProUGUI.text = _characterData.HealthReadOnly.Value.ToString();
                _healthView._slider.value = _characterData.HealthReadOnly.Value;

            }).AddTo(_disposable);
        }
    }
}