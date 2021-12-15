using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float speed = 8;
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

    }
}
