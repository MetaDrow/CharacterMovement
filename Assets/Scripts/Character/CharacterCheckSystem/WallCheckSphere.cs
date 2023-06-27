using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckSphere : MonoBehaviour
{

    [SerializeField] public LayerMask _wallLayerMask;
    [SerializeField] public LayerMask _wallTopMask;
    [SerializeField] internal Character _character;


    private void OnTriggerEnter(Collider other)
    {
        if ((_wallLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

          //  Debug.Log("Hit enter" + other.gameObject.layer);
            _character._isWall = true;
        }
        if ((_wallTopMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

            Debug.Log("Hit enter" + other.gameObject.layer);
            _character._isWallTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_wallLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

           // Debug.Log("Hit exit" + other.gameObject.layer);
            _character._isWall = false;
        }


        if ((_wallTopMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {

          //  Debug.Log("Hit exit" + other.gameObject.layer);
            _character._isWallTop = false;
        }

    }

}
