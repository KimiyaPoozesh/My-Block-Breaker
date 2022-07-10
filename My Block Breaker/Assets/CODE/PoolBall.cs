using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBall : MonoBehaviour
{
   public float speed = 5000f; 

    public Rigidbody rb;
    public float forwardForce = 20000f;
    public GameObject GameOjectYouWantToClone;

    public void Start()
    {
        StartCoroutine(SetRandomTrajectory ());
    }

    private  IEnumerator SetRandomTrajectory(){

        
    yield return new WaitForSeconds(1f);

    Vector3 force = Vector3.zero;
    force.x = Random.Range(-1f,1f);
    force.y = 0;
    force.z = 1f;

    rb.AddForce(force.normalized *speed);
    }
    public void OnCollisionEnter(Collision collision){
            Debug.Log(gameObject.tag);

      if(collision.gameObject.tag=="Bricks"){
        Destroy(collision.gameObject);
    }
    //     if(collision.gameObject.tag=="Wall"){
    //     collisionInfo.gameObject.GetComponent<ParticleSystem>().Play(); 
    //     Destroy(GameOjectYouWantToClone);
    // }
    if(collision.gameObject.tag=="Boat"){
        Debug.Log("in");
        GameObject CloneOfGameOject = Instantiate(GameOjectYouWantToClone);
    }
}


    
    
}
