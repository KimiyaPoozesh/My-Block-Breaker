using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public void Update(){

    }
     public void OnCollisionEnter(Collision collision){
      if(collision.gameObject.name=="Bricks"){
        Destroy(collision.gameObject);
    }
        // Destroy(gameObject);
        // print("hi");


    }
}
