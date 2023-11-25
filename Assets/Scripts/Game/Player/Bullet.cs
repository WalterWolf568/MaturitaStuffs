using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
