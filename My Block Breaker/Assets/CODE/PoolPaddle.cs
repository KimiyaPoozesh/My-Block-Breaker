
using UnityEngine;

public class PoolPaddle : MonoBehaviour
{
 Vector3 Vec;  
    // Start is called before the first frame update  
    void Start()  
    {  
          
    }  
  
    // Update is called once per frame  
    void Update()  
    {  
  
        Vec = transform.localPosition;  
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;  
        transform.localPosition = Vec;  
    } 

}
