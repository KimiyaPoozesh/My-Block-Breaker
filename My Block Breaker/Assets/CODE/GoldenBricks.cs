using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBricks : MonoBehaviour
{
     public float speed = 5000f; 
    public Rigidbody rb;

      public void Start()
    {
        StartCoroutine(SetRandomTrajectory ());
        
    }

    private  IEnumerator SetRandomTrajectory(){

        
    yield return new WaitForSeconds(1f);
    Vector3 force = Vector3.zero;
    force.x = 0;
    force.y = 0;
    force.z = Random.Range(-1f,1f);

    rb.AddForce(force.normalized *speed);
    }

  

}

