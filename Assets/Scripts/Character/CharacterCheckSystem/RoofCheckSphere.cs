using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCheckSphere : MonoBehaviour
{
    [SerializeField] public LayerMask _ceilingLayerMask;
    [SerializeField] internal Character _character;



    private void OnTriggerEnter(Collider other)
    {
        if ((_ceilingLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

         //   Debug.Log("Hit enter" + other.gameObject.layer);
            _character._isCeiling = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_ceilingLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

           // Debug.Log("Hit exit" + other.gameObject.layer);
            _character._isCeiling = false;


        }

    }



}
