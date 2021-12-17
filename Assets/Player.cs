using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletFab;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);
    }


    float speed = 10;
    public float bullet_speed;
    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 dir = input.normalized;
        Vector3 velocity = dir * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.position += moveAmount;


        //shoot
        if(Input.GetKeyDown(KeyCode.Space) && velocity.magnitude != 0){
        GameObject projectile =  Instantiate(bulletFab, transform.position, Quaternion.FromToRotation(new Vector3(0, 0, 1), dir));
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.velocity = dir * 20;
        rb.useGravity = false;
        }

        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            Vector3 mouseDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized;

            print(Camera.main.ScreenToWorldPoint(Input.mousePosition));


            GameObject projectile =  Instantiate(bulletFab, transform.position, Quaternion.FromToRotation(new Vector3(0, 0, 1), mouseDir));
            Rigidbody rb = projectile.AddComponent<Rigidbody>();
            rb.velocity = mouseDir * 20;
            rb.useGravity = false;
        }

        
        
    }


        void OnTriggerEnter(Collider other){
            if(other.gameObject.tag == "Enemy"){
                Destroy(other.gameObject);
            }
        }

}