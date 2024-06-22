using UnityEngine;
using Platformer.Character;


public class WallCheckSphere : MonoBehaviour
{
    [SerializeField] private LayerMask _wallLayerMask;
    [SerializeField] private LayerMask _wallTopMask;
    [SerializeField] private CharacterData _characterData;

    private void OnTriggerEnter(Collider other)
    {
        if ((_wallLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _characterData._isWall = true;
        }

        if ((_wallTopMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            //_characterData._isWallTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_wallLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _characterData._isWall = false;
        }

        if ((_wallTopMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            //_characterData._isWallTop = false;
        }
    }
}
