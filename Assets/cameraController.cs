using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform target;

	void Start () {
		
	}
	
	void Update () {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(target.position.x, transform.position.y, target.position.z), 1.0f);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);
    }
}
