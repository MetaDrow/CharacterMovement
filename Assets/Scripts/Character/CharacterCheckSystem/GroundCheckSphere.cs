using UnityEngine;

internal class GroundCheckSphere : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Character _character;

    private void OnTriggerStay(Collider other)
    {
        if ((_groundLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_groundLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _character._isGrounded = false;
        }
    }
}

