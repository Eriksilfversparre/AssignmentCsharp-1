using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isActive;
    private Transform rotation;

    public void Initialize()
    {
        isActive = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
