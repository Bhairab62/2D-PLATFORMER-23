using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float AliveTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, AliveTime);
    }
}
