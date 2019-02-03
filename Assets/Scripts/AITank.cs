using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITank : Unit {
    [HideInInspector] public GameObject m_Instance;

    public float enemySearchRange;
    public GameObject enemy;

    public float moveSpeed;
    public float rotateSlerpParameter;

    public ISRange attackRange;
    public ISRange stoppingDistance;
    private float currentAttackRange;
    private float currentStoppingDistance;

    public float RandomTimerInterval;


    private TankWeapon tw;

    private NavMeshAgent nma;

    private void Start()
    {
        enemyLayerMask = LayerManager.GetEnemyLayer(team);
        tw = GetComponent<TankWeapon>();
        tw.Init(team);
        //nma = GetComponent<NavMeshAgent>();

       // StartCoroutine(RandomTimer());


    }
    /*
    private void FixedUpdate()
    {
        if (enemy == null)
        {
            SearchEnemy();
            return;
        }

        Vector3 dir = enemy.transform.position - transform.position;
        
        
        float dist = Vector3.Distance(enemy.transform.position, gameObject.transform.position);

        if(dist > this.currentStoppingDistance)
        {
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            nma.SetDestination(enemy.transform.position);
        }else
        {
            //transform.LookAt(player.transform.position);
            //nma.SetDestination(transform.position);
            nma.ResetPath();

            Quaternion wantedRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotateSlerpParameter * Time.deltaTime);
        }

        if (dist < this.currentAttackRange)
        {
            tw.Shoot();
        }

    }
    */
    public void SearchEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, enemySearchRange, enemyLayerMask);
        if(cols.Length > 0)
        {
            float curMinDist = Mathf.Infinity;
            for(int i=0; i<cols.Length; i++)
            {
                float curDist = Vector3.Distance(transform.position, cols[i].transform.position);
                if (curDist < curMinDist)//find the closest enemy
                {
                    curMinDist = curDist;
                    enemy = cols[i].gameObject;
                }
            }
         //   enemy = cols[Random.Range(0, cols.Length)].gameObject; //search a random enemy
        }
        
    }


    IEnumerator RandomTimer()
    {
        while (enabled) // If the Box Collider is selected;
        {
            this.currentAttackRange = ISMath.Random(this.attackRange);
            this.currentStoppingDistance = ISMath.Random(this.stoppingDistance);
            this.currentStoppingDistance = Mathf.Min(currentAttackRange, currentStoppingDistance);

            SearchEnemy();
            yield return new WaitForSeconds(this.RandomTimerInterval);
        }
        
        
    }
}
