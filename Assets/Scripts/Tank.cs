using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {

    [HideInInspector] public GameObject m_Instance;
    public float moveSpeed;
    public float rotateSpeed;

    private TankWeapon tw;
	// Use this for initialization
	void Start () {
        InitTeam(Team.Green);
        tw = GetComponent<TankWeapon>();
        tw.Init(team);   
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal1");//left and right
        float vertical = Input.GetAxis("Vertical1");//forward and back
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vertical );
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fire the shell/cannon
            tw.Shoot();
        }

        /* Interesting moving 
        transform.Translate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);
        */

        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }//Vector3.forward = new Vector3(0, 0, 1)

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }//Vector3.back = new Vector3(0, 0, -1)

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }//Vector3.up = new Vector3(0, 1, 0)

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }//Vector3.down = new Vector3(0, -1, 0)
        */
    }
}
