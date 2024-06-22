using HealthSystem;
using NUnit.Framework;
using Platformer.Character;
using UnityEngine;

public class CharacterHealthSystemTest
{
    [Test]
    public void CharacterHealthStartCurrentValue()
    {
        CharacterData characterData = ScriptableObject.CreateInstance<CharacterData>();
        CharacterHealthModel characterHealthModel = new CharacterHealthModel(null, characterData, null);
        characterHealthModel.CharacterInitHealthValue();

        int expectedStartHealthValue = 100;

        Assert.IsTrue(expectedStartHealthValue == characterHealthModel._characterData.Health.Value);
    }

    [Test]
    public void CharacterHealthTakeDamage()
    {
        CharacterData characterData = ScriptableObject.CreateInstance<CharacterData>();
        CharacterHealthModel characterHealthModel = new CharacterHealthModel(null, characterData, null);
        characterHealthModel.CharacterInitHealthValue();

        var characterGameObject = new GameObject();
        var character = characterGameObject.AddComponent(typeof(Character)) as Character; // initializing the character
        character._characterData = characterData;

        character.TakeDamage(20);
        int afterDamageValue = character.Data.Health.Value;
        int expectedValue = 80;
        Assert.IsTrue(afterDamageValue == expectedValue);

        character.TakeDamage(200);
        Assert.IsTrue(afterDamageValue >= 0); // it should not be negative
    }
}