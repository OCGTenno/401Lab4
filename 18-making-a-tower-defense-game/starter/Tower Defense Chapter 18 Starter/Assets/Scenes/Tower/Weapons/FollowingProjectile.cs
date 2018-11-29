using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowingProjectile : MonoBehaviour {

    // Sets the enemy the projectile needs to follow and the projectile speed
    // Checks if the enemys hit or destroyed and if so destroy the projectile
    public Enemy enemyToFollow;
    
    public float moveSpeed = 15;
    private void Update()
    {
        
        if (enemyToFollow == null)
        {
            Destroy(gameObject);
        }
        else
        { 
            transform.LookAt(enemyToFollow.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() == enemyToFollow)
        {
            OnHitEnemy();
        }
    }
    
    protected abstract void OnHitEnemy();
}
