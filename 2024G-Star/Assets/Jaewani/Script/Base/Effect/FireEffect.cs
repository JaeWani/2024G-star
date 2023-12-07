using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    [SerializeField] private string key;
    private void OnParticleSystemStopped()
    {
        PoolManager.ReturnToPool(key,gameObject);
    }
}
