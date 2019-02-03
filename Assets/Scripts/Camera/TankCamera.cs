using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCamera : MonoBehaviour {

    public Transform target;

    // Update is called once per frame
    /*	void Update () {
            transform.position = target.position;
        }
        */
    //LateUpdate is called once per frame but at the end
    private void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.position;
    }
}
