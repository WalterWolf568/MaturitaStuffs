using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public Vector3 offset;


    private float maxPosition = 90f;

    public void LateUpdate()
    {

        Vector3 desiredPosition = player.position + offset;


        desiredPosition.x = Mathf.Clamp(desiredPosition.x, -maxPosition, maxPosition);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, -maxPosition, maxPosition);


        transform.position = desiredPosition;
    }
}