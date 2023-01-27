using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    public float timeAlive;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeAlive);
    }
}
