using UnityEngine;

public class CeilingCheckSphere : MonoBehaviour
{
    [SerializeField] private LayerMask _ceilingLayerMask;
    [SerializeField] private Character _character;

    private void OnTriggerEnter(Collider other)
    {
        if ((_ceilingLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isCeiling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_ceilingLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isCeiling = false;

        }
    }
}
