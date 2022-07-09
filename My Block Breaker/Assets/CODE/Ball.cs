using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public Rigidbody rb ;
  public float speed = 5000f; 

  private void Start (){
   Invoke(nameof(SetRandomTrajectory),1f);
  }

  private void SetRandomTrajectory(){
     Vector3 force = Vector3.zero;
    force.x = Random.Range(-1f,1f);
    force.y = -1f;
    force.z = 0;

    rb.AddForce(force.normalized *speed);

    
  }
      public void OnCollisionEnter(Collision collision){
      if(collision.gameObject.tag=="Bricks"){
        Destroy(collision.gameObject);
    }
        // Destroy(gameObject);

    }
}
