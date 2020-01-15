using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D BallRigidbody;
    public float speed = 5.0f;

    // Как долго существует лазер
    public float lifetime = 2.0f;

    public float timeBeforeSpawning = 1.5f;
    void Start()
    {
        // Уничтожение лазера по окончанию таймера
        Destroy(gameObject, lifetime);
    }

 
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    
}
