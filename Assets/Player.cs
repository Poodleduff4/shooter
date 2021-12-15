using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);
    }


    float speed = 10;
    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 dir = input.normalized;
        Vector3 velocity = dir * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        // print(input);
        transform.position += moveAmount;

        if(Input.GetKeyDown(KeyCode.Space) && velocity.magnitude != 0){
        GameObject projectile =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
        projectile.transform.position = transform.position;
        projectile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.detectCollisions = false;
        rb.velocity = dir * 20;
        rb.useGravity = false;
        }

        void OnBecameInvisible(){
            Destroy(gameObject);
            print("ayo");
        }

        void OnTriggerEnter(Collider other){
                print("ayo");
        }
        
        
    }
}