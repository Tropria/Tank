using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Green, Red, Blue
}

public class Unit : MonoBehaviour {

    public Team team;
    public LayerMask enemyLayerMask;

    public int maxHealth = 100;
    public int health = 100;
    public GameObject deadEffect;

    public void InitTeam(Team tm)
    {
        team = tm;
        if (team == Team.Red)
        {
            Debug.Log("This is an enemy's tank");
            gameObject.layer = LayerManager.redLayer;
        }
        if (team == Team.Green)
        {
            Debug.Log("This is a player's tank");
            gameObject.layer = LayerManager.greenLayer;
        }
        enemyLayerMask = LayerManager.GetEnemyLayer(team);
    }


    public void ApplyDamage(int damage)
    {
        if(damage < health)
        {
            health -= damage;
        } else
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        health = 0;
        if(deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
	
}
