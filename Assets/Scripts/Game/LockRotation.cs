using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial local rotation of the Graphics object relative to the parent
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Continuously reset the Graphics object's local rotation to its initial state
        // This effectively ignores the parent's (player object's) rotation
        transform.rotation = initialRotation;
    }
}
