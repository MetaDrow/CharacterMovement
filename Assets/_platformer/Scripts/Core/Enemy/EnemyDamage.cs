using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable component))
        {
            component.TakeDamage(_damage);
        }
        else
        {
            Debug.Log($"Check now = {other.name}");
        }
    }
}
