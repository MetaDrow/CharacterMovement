using UnityEngine;

internal class GroundCheckSphere :MonoBehaviour
{

    [SerializeField] public LayerMask _groundLayerMask;
    [SerializeField] public Transform _groundTransform;
    [SerializeField] public float _groundSphereRadius;
    [SerializeField] internal Character _character;


    private void OnTriggerStay(Collider other)
    {
        if ((_groundLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

            //  Debug.Log("Hit enter" + other.gameObject.layer);
            _character._isGrounded = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if ((_groundLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

            //  Debug.Log("Hit enter" + other.gameObject.layer);
            _character._isGrounded = false;
        }
    }


}
