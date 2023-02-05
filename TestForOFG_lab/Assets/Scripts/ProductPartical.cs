using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPartical : MonoBehaviour
{
    private ParticleSystem _particalRubSystem;

    private void Start()
    {
        _particalRubSystem = GetComponent<ParticleSystem>();
        _particalRubSystem.Play();
    }

    private void Update()
    {
        if (_particalRubSystem.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
