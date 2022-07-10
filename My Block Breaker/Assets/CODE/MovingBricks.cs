using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBricks : MonoBehaviour
{
    public Rigidbody rb ;
        void Update()
    {
        float a = Random.Range(-0.01f,01f);
            transform.Translate(0f, 0f,a);  

    }
}
