
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class illuminate : MonoBehaviour
{
    float timeLeft;
    public Light l;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            l.enabled = !l.enabled;
            timeLeft = 0.5f;
        }
    }
}
