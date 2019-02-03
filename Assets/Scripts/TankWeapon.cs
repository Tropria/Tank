using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {
    
    public GameObject shell;//Gameobject shell
    public float shootPower;//The power of this shooting
    public Transform shootPoint;//Transform

    private AudioSource audioS;

    public LayerMask enemyLM;

    public float shootCoolDown;
    private bool isWeaponReady = true;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void Init(Team team)
    {
        enemyLM = LayerManager.GetEnemyLayer(team);
    }

    void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fire the shell/cannon
            Shoot();
        }
        */
	}

    public void Shoot()
    {
        if (!isWeaponReady) return;
        GameObject newShell = Instantiate(shell, shootPoint.position, shootPoint.rotation);
        newShell.GetComponent<Shell>().Init(enemyLM);
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward * shootPower;

        audioS.Play();

        isWeaponReady = false;
        StartCoroutine(WeaponCooldown());
    }

    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(shootCoolDown);
        isWeaponReady = true;
    }
}
