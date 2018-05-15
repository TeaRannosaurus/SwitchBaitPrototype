using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    [Header("Visable but untweakable Properties")]
    public float damage;
    //public float splashRadius;
    public float travelSpeed;
    public Vector3 startSpeed;

    private bool _hasBeenTriggered = false;

    void Start () {
        _hasBeenTriggered = false;
    }

    public void Init(float Damage, float TravelSpeed, Vector3 CurrentSpeed)
    {
        damage = Damage;
        travelSpeed = TravelSpeed;
        startSpeed = CurrentSpeed;

        // Give the bullet a force
        transform.GetComponent<Rigidbody>().velocity = startSpeed;
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * travelSpeed);

    }

    void Update () {
        /* if (target == null)
        {
            Destroy(gameObject);
            return;
        }*/

        //float step = travelSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, moveDir, step);
    }

    public void OnTriggerEnter(Collider other)
    {
        //print("Something Hit!");
        //if (_hasBeenTriggered)
        //    return;

        //_hasBeenTriggered = true;
        
        if (other.tag == "Enemy")
        {
            print("Enemy Hit!");
            other.GetComponent<EnemyController>().TakeDamage((int)damage);
            Destroy(gameObject); 
        }

    }
}