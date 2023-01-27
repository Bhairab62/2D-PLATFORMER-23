using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float StartPos, Length;
    public float ParallaxX;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        Length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float DistanceX = cam.transform.position.x * ParallaxX;
        transform.position = new Vector3(StartPos + DistanceX, transform.position.y, transform.position.z);
/*        float temp = cam.transform.position.x * (1 - ParallaxX);
        if (temp > StartPos + Length)
            StartPos += Length;*/
    }
}
