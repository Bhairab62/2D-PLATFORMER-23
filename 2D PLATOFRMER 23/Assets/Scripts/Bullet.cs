using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject HitEffect;
    public float Speed = 10f;
    public float timeAliveBullet = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeAliveBullet);
    }
    private void Update()
    {
        rb.velocity = transform.right * Speed*Time.fixedDeltaTime; 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(HitEffect, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
