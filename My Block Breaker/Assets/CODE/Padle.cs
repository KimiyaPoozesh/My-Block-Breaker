
using UnityEngine;

public class Padle : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 direction;
    public float speed = 30f;
    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    private void Update(){
        rb.AddForce(0,500* Time.deltaTime,0);
        rb.AddForce(0,-500* Time.deltaTime,0);

    }

    // private void FixedUpdate(){
    //     if(this.direction != Vector3.zero){
    //         this.rb.AddForce(this.direction * this.speed,0,0);
    //     }
    // }

    public void FixedUpdate(){
        if( Input.GetKey("a")){
            rb.AddForce(-500* Time.deltaTime,0,0);
        }
        if( Input.GetKey("d")){
            rb.AddForce(500* Time.deltaTime,0,0);
        }
    }
}
