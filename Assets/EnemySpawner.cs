using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies;
    public int numEnemies;
    public float EnemySpawnTime;

    float initialTime;
    // Start is called before the first frame update
    void Start()
    {

        float initialTime = Time.fixedTime;

         //break cause there's gonna be more than numEnemies
        for(int i = 0;i < numEnemies;i++){
            
            Enemies.Add(CreateEnemy());
        }
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Time.fixedTime - initialTime > EnemySpawnTime){
            //create enemy
            // print("create");
            Enemies.Add(CreateEnemy());
            initialTime = Time.fixedTime;
        }

    }

    GameObject CreateEnemy(){
        Vector3 min = new Vector3(-10, -10, -10);
        Vector3 max = new Vector3(10, 10, 10);
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy.name = "Enemy";
        enemy.tag = "Enemy";
        
        enemy.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        Vector3 pos = new Vector3(Random.Range(min.x, max.x), 0, UnityEngine.Random.Range(min.z, max.z));

        enemy.transform.position = pos;
        enemy.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        Collider collide = enemy.GetComponent<Collider>();
        collide.isTrigger = true;
        Rigidbody rb = enemy.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        

        return enemy;
    }

    void OnTriggerEnter(Collider other){
                print("ayo");
        }
}
