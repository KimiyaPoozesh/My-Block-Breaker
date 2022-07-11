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
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
     private Vector3 BallPos;
    public Vector3 sizeChange;
    public ParticleSystem explosion;
    public AudioSource sound;
    public static int count=0;
    public static int health=3;
    public void Start()
    {
        StartCoroutine(SetRandomTrajectory ());
        explosion.Stop();
        sound.Stop();
        count++;
        BallPos = transform.position;
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
            force.z = 2f;



        if(collision.gameObject.tag=="Bricks"){
            Destroy(collision.gameObject);}

            if(collision.gameObject.tag=="Wall"){
                health--;
                if(health==0)
                {
                    var HealthRenderer = heart3.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.white);
                    sound.Play();
                    explosion.Play();
                    Destroy(ball);
                    Destroy(paddlle);
                    }
                else if (health==1){
                    var HealthRenderer = heart2.GetComponent<Renderer>();
                    sound.Play();
                    explosion.Play();
                    HealthRenderer.material.SetColor("_Color", Color.white);
                    ball.transform.position = new Vector3(BallPos.x,BallPos.y,BallPos.z);

                }
                else if (health==2){
                    var HealthRenderer = heart1.GetComponent<Renderer>();
                    sound.Play();
                    explosion.Play();
                    HealthRenderer.material.SetColor("_Color", Color.white);
                    ball.transform.position = new Vector3(BallPos.x,BallPos.y,BallPos.z);
                }
                
        }
        if(collision.gameObject.tag=="Boat" && count<2){
            // health+=2;
            // if(health==0)
            //     {
            //         var HealthRenderer = heart3.GetComponent<Renderer>();
            //         HealthRenderer.material.SetColor("_Color", Color.red);
            //         }
            //     else if (health==1){
            //         var HealthRenderer = heart2.GetComponent<Renderer>();
            //         HealthRenderer.material.SetColor("_Color", Color.red);


            //     }
            //     else if (health==2){
            //         var HealthRenderer = heart1.GetComponent<Renderer>();
            //         HealthRenderer.material.SetColor("_Color", Color.red);
                    
            //     }
            //     else if(health>3){
            //         var HealthRenderer = heart1.GetComponent<Renderer>();
            //         HealthRenderer.material.SetColor("_Color", Color.yellow);
                    
            //     }
//--------------------------------------------------------------------------------------------------------
            GameObject CloneOfGameOject = Instantiate(ball,new Vector3(ball.transform.position.x
            ,ball.transform.position.y,
            ball.transform.position.z),
            ball.transform.rotation);
            rb.AddForce(force.normalized *speed);
            
            }
        
        if(collision.gameObject.tag=="SUPER"){
            if(ball.transform.localScale.x + 2f<8)
            {       transform.localScale = ball.transform.localScale + sizeChange;
                    rb.AddForce(force.normalized *speed);

            }
        }
        if(collision.gameObject.tag=="knife"){
            if(ball.transform.localScale.x - 2f>3)
            {transform.localScale = ball.transform.localScale - sizeChange;
            rb.AddForce(force.normalized *speed);
    }
        }

        if(collision.gameObject.tag=="SUPER2"){
        
            if(paddlle.transform.localScale.x + 2f<16)
            {
                paddlle.transform.localScale = paddlle.transform.localScale + sizeChange;   
                Destroy(collision.gameObject);
            }

        }

        if(collision.gameObject.tag=="Golden"){
            GameObject[] Goldens = GameObject.FindGameObjectsWithTag("Golden");   
            foreach (GameObject Golden in Goldens) {
            Destroy(Golden);

            }
            rb.AddForce(force.normalized *(speed+1000));
        }
        if(collision.gameObject.tag=="Heart"){
            health++;
            if(health==0)
                {
                    var HealthRenderer = heart3.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.red);
                Destroy(collision.gameObject);
                    }
                else if (health==1){
                    var HealthRenderer = heart2.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.red);
                Destroy(collision.gameObject);


                }
                else if (health==2){
                    var HealthRenderer = heart1.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.red);
                Destroy(collision.gameObject);

                }
                else if(health>3){
                    var HealthRenderer = heart1.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.blue);
                    Destroy(collision.gameObject);

                }

        }
    }
    
}
