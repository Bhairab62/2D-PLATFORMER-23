using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool FacingLeft = false;
    bool Attack = true;
    Transform player;
    Rigidbody2D rb;

    //[SerializeField] float BulletSpeed = 10f;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform ShootPoint;
    [SerializeField] GameObject EffectBullet;

    public float StartTime = 2f;
    private float TimeBetweenShoot;
    public float ShootRange;
    public int MaxHealth = 10;
    void Start()
    {
        TimeBetweenShoot = StartTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D collInfo = Physics2D.OverlapCircle()

        if (transform.position.x > player.position.x && !FacingLeft)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            FacingLeft = true;
        }
        else if (transform.position.x < player.position.x && FacingLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            FacingLeft = false;
        }

        if (Vector2.Distance(rb.position, player.position) <= ShootRange)
        {
            if (TimeBetweenShoot <= 0)
            {
                Shoot();
                TimeBetweenShoot = StartTime;
            }
            else
            {
                TimeBetweenShoot -= Time.deltaTime;
            }
        }
    }
    public void Shoot()
    {
        //FindObjectOfType<CinemachineCameraShake>().CameraShake(2f, 1f);
        Instantiate(EffectBullet, ShootPoint.position, ShootPoint.rotation);
        Instantiate(BulletPrefab, ShootPoint.position, ShootPoint.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "sword")
        {
            Debug.Log("sword attack!!");
            MaxHealth -= 1;
            if (MaxHealth <= 0)
            {
                Die();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Attack = true;
    }
    void Die()
    {
        Debug.Log("Enemy Has Been Died!!");
        Destroy(gameObject);
    }
}
