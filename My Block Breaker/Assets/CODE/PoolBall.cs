using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolBall : MonoBehaviour
{
    public UnityEvent onCollisonEvent;
   public float speed = 5000f; 
   public AudioSource music2;
private Shake shake;
    public Rigidbody rb;
    public float forwardForce = 20000f;
    public GameObject ball;
    public GameObject paddlle;
    public GameObject cam1;
    public GameObject cam2;

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
        cam2.SetActive(false);
        cam1.SetActive(true);
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
        public void     OnCollisionEnter(Collision collision){
            onCollisonEvent?.Invoke();

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
                    GameObject[] Balls = GameObject.FindGameObjectsWithTag("Ball");   
                foreach (GameObject Ball in Balls) {
                 Destroy(Ball);
                }
                   
                    Destroy(paddlle);
                     cam1.GetComponent<AudioListener> ().enabled  =  false;
                     cam2.GetComponent<AudioListener> ().enabled  = true;

                    cam1.SetActive(false);
                    cam2.SetActive(true);
                    music2.Play();

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
        if(collision.gameObject.tag=="Boat"){
            rb.AddForce(force.normalized *speed);

            if(count <2)
            {GameObject CloneOfGameOject = Instantiate(ball,new Vector3(ball.transform.position.x
            ,ball.transform.position.y,
            ball.transform.position.z),
            ball.transform.rotation);}
            
            }
        
        if(collision.gameObject.tag=="SUPER"){
            rb.AddForce(force.normalized *speed);

            if(ball.transform.localScale.x + 2f<8)
            {       transform.localScale = ball.transform.localScale + sizeChange;

            }
        }
        if(collision.gameObject.tag=="knife"){
            rb.AddForce(force.normalized *speed);
            if(ball.transform.localScale.x - 2f>3)
            {
                 GameObject[] Balls = GameObject.FindGameObjectsWithTag("Ball");   
                foreach (GameObject Ball in Balls) {
                    transform.localScale = ball.transform.localScale - sizeChange;
                }
            }
        }

        if(collision.gameObject.tag=="SUPER2"){
        rb.AddForce(force.normalized *speed);

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
            rb.AddForce(force.normalized *(speed+1000));

            health++;
            Destroy(collision.gameObject);
            if(health==0)
                {
                    var HealthRenderer = heart3.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.red);
                    }
                else if (health==1){
                    var HealthRenderer = heart2.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.red);

                }
                else if (health==2){
                    var HealthRenderer = heart1.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.red);
                }
                else if(health>3){
                    var HealthRenderer = heart1.GetComponent<Renderer>();
                    HealthRenderer.material.SetColor("_Color", Color.blue);
                }

        }
    }
    
}
