using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBall : MonoBehaviour
{
   public float speed = 5000f; 

    public Rigidbody rb;
    public float forwardForce = 20000f;
    public GameObject ball;
    public GameObject paddlle;
    
    public Vector3 sizeChange;
    public ParticleSystem explosion;
    public AudioSource sound;


    public static int count=0;
    public void Start()
    {
        StartCoroutine(SetRandomTrajectory ());
        explosion.Stop();
        sound.Stop();
        count++;
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

        Vector3 force = Vector3.zero;
    force.x = Random.Range(-1f,1f);
    force.y = 0;
    force.z = 1f;



        Debug.Log(gameObject.tag);

      if(collision.gameObject.tag=="Bricks"){
        Destroy(collision.gameObject);}

        if(collision.gameObject.tag=="Wall"){
        sound.Play();
        explosion.Play();

        Destroy(ball);
    }
    if(collision.gameObject.tag=="Boat" && count==1){
        GameObject CloneOfGameOject = Instantiate(ball,new Vector3(ball.transform.position.x
        ,ball.transform.position.y,
        ball.transform.position.z),
        ball.transform.rotation);
        }
    
    if(collision.gameObject.tag=="SUPER"){
        if(ball.transform.localScale.x + 2f<8)
        {transform.localScale = ball.transform.localScale + sizeChange;}
    }
     if(collision.gameObject.tag=="knife"){
        if(ball.transform.localScale.x + 2f>3)
        {transform.localScale = ball.transform.localScale - sizeChange;}
    }

    if(collision.gameObject.tag=="SUPER2"){
     
        if(paddlle.transform.localScale.x + 2f<16)
        {paddlle.transform.localScale = paddlle.transform.localScale + sizeChange;   
        Destroy(collision.gameObject);}

    }

    if(collision.gameObject.tag=="Golden"){
        GameObject[] Goldens = GameObject.FindGameObjectsWithTag("Golden");   
        foreach (GameObject Golden in Goldens) {
	    Destroy(Golden);
        }
    }
}
}
