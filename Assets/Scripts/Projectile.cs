using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    [Header("Visable but untweakable Properties")]
    public float damage;
    //public float splashRadius;
    public float travelSpeed;
    public Vector3 moveDir;

    private bool _hasBeenTriggered = false;

    void Start () {
        _hasBeenTriggered = false;
    }

    public void Init(float Damage, float TravelSpeed, Vector3 MoveDir)
    {
        damage = Damage;
        travelSpeed = TravelSpeed;
        moveDir = MoveDir;
    }

    void Update () {
        /* if (target == null)
        {
            Destroy(gameObject);
            return;
        }*/

        float step = travelSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveDir, step);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (_hasBeenTriggered)
            return;

        _hasBeenTriggered = true;
        
        // if (other.transform == target)
        // {
            //other.GetComponent<EnemyBase>().TakeDamage(damage);
        //     OnHitEnemy();
        // }
            //GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnHitEnemy()
    {
        //m_soundEffectManager.PlaySound(m_hitSounds);
        //GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 0.5f);
    }

}