using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [HideInInspector]
    public bool shouldRotate = false;
    /*public*/private float currentRotation = 0.0f; /*(degrees)*/

    // Values used to set the min 
    // and max angle for the turret
    public float maxRotation = 360.0f;
    public float minRotation = 0.0f;

    private Transform _pTransform;

    private Camera _camera;

    private Vector3 _mousePos;
    private Vector3 _turretPos;
    private float _aimAngle;

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;


    //// USED FOR DEBUG DRAWING (previously used to check forward facing vector location/direction)
    //void OnDrawGizmos()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position + _pTransform.forward, 1);
    //}


    void Start () {

        _pTransform = gameObject.transform;

        _camera = Camera.main;
	}

	void Update () {
        // Handle all turret movement here

        if (shouldRotate)
        {
            _mousePos = Input.mousePosition;
            _mousePos.z = _camera.nearClipPlane;
            _turretPos = _camera.WorldToScreenPoint(_pTransform.position);
            _mousePos.x -= _turretPos.x;
            _mousePos.y -= _turretPos.y;
            _aimAngle = (Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg) + 180.0f; // +180.0f to make sure it's always positive
            
            //print(_aimAngle);

            // And use that angle to see whether it's between chosen bounds
            if (_aimAngle < maxRotation && _aimAngle > minRotation)
            {
                Quaternion tmpQuat = Quaternion.Euler(new Vector3(0.0f, _aimAngle + 90.0f, 0.0f));
                // Flip the rotation
                _pTransform.rotation = Quaternion.Euler(-tmpQuat.eulerAngles);
            }
        }

    }


    public void Shoot()
    {
        print("Shoot!");
    }
}



//// Get vector between turret center and mouse pos
//// First, convert the screen mouse pos to world mouse pos
//Vector3 mousePos3D = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));
//Vector2 mousePos2D = new Vector2(mousePos3D.x, mousePos3D.z);

//// Then, get the weapon position
//Vector2 turretPos = new Vector2(_pTransform.position.x, _pTransform.position.z);

//// Then, check what the angle between the two is
//float angle = Vector2.Angle(turretPos, mousePos2D);

//print(mousePos3D);