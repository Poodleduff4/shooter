using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public Transform targetTransform;

    public GameObject BulletFab;

    float initialTime;

    public float shootInterval;
    // Start is called before the first frame update

    float speed = 8;
    public float bullet_speed;

    GameObject closest;
    void Start()
    {
        initialTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = targetTransform.position - transform.position;
        Vector3 dir = difference.normalized;
        Vector3 velocity = dir * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        if(difference.magnitude > 2){
        transform.position += moveAmount;
        }

        //shoot
        if(Time.fixedTime - initialTime > shootInterval){
            CreateBullet();
            initialTime = Time.fixedTime;
        }

    }

    void CreateBullet(){
        Vector3 dir = (FindNearestEnemy(transform.position).transform.position - transform.position).normalized;
        GameObject projectile =  Instantiate(BulletFab, transform.position, Quaternion.FromToRotation(new Vector3(0, 0, 1), dir));
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.velocity = dir * 20;
        rb.useGravity = false;
    }

    GameObject FindNearestEnemy(Vector3 pos){
        
        GameObject[] objects = FindObjectsOfType<GameObject>();
        for (int i = 0;i < objects.Length;i++){
            if(i == 0){
                closest = objects[0];
            }
            if(objects[i].gameObject.tag == "Enemy"){
                if(Vector3.Distance(pos, objects[i].gameObject.transform.position) < Vector3.Distance(pos, closest.transform.position)){
                    closest = objects[i];
                }
            }
        }
        return closest;
    }

    
}
