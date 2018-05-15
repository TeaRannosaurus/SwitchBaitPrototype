using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamagable
{
    public Transform target;
    public int maxHealth = 100;
    public float movementSpeed = 10;

    private int _currentHealth; 
    private NavMeshAgent _agent;

	// Use this for initialization
	void Start ()
	{
	    _currentHealth = maxHealth;
	    _agent = GetComponent<NavMeshAgent>();
	    _agent.speed = movementSpeed;
	}
	

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        _agent.destination = target.position;
    }

    private void Update()
    {
        _agent.destination = target.position;
    }

	public void TakeDamage(int amount)
	{
	    _currentHealth -= amount;

        if(_currentHealth <= 0)
            Die();
	}

	public void Die()
	{
		Destroy(this.gameObject);
	}
}
