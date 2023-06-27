using UnityEngine;

internal class WallCheckSphere : MonoBehaviour
{
    [SerializeField] private LayerMask _wallLayerMask;
    [SerializeField] private LayerMask _wallTopMask;
    [SerializeField] private Character _character;

    private void OnTriggerEnter(Collider other)
    {
        if ((_wallLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isWall = true;
        }
        if ((_wallTopMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isWallTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_wallLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isWall = false;
        }

        if ((_wallTopMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isWallTop = false;
        }
    }
}
