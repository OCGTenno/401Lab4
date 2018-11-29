using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : FollowingProjectile {

    // Amount of damage to dish out to an enemy
    public float damage;
   
    protected override void OnHitEnemy()
    {
       
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }
}
