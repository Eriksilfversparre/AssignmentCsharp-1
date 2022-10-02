using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCamera : MonoBehaviour
{
    [SerializeField] private STurnManager manager;
    [SerializeField] private Vector3 disntanceFromPlayer;
    [SerializeField] private float cameraSpeed;

    private void Update()
    {
        Vector3 targetPosition = manager.GetCurrentPlayer().transform.position + disntanceFromPlayer;


        float step = cameraSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
