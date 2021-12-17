using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public GameObject ExplosionFab;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Bullet"){
            GameObject Explosion = Instantiate(ExplosionFab);
            ParticleSystem particleSys = ExplosionFab.GetComponent<ParticleSystem>();
            Explosion.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(other.gameObject);
            Destroy(Explosion, 1.5f);

        }
    }
}
