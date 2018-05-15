using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    enum PlayerState { WALK, WEAPON };

    [Header("Movement Properties")]
    public float walkSpeed = 1.0f;
    //public float size = 1.0f;

    private float _currentSpeed;

    private Rigidbody _rb;

    private PlayerState _pState;

    private Weapon _controlledWeapon;

    //private SphereCollider _searchArea;

    // Bool that checks whether the 'action button (E)' is pressed, 
    // and makes sure only one action can be done at a time
    private bool _isActionPressed; 



	void Start () {
        _rb = GetComponent<Rigidbody>();
        //_searchArea = GetComponent<SphereCollider>();
	}

    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.tag == "Weapon")
        {
            print("Weapon in range!");
            // First in Update(), but moved it to OnTriggerEnter for improved 
            if (_pState == PlayerState.WALK)
            {
                // Handle player action input in WALK state (entering a weapon)

                // Add an option to enter a weapon
                if (!_isActionPressed && Input.GetKeyDown(KeyCode.E))
                {
                    _isActionPressed = true;
                    // Give player control to chosen weapon, set weapon transform

                    // Search area (use circle collider) for available turret
                    // Select closest turret as chosen turret
                    //NOTE: Since we only have a single player, we count every turret as 'available'
                    //NOTE: In-engine, we could better check for the distance between the closest 
                    //      available turret and the target player, and see whether that's below 
                    //      a certain threshold/range

                    _controlledWeapon = obj.GetComponent<Weapon>();
                    print(_controlledWeapon.name);
                    _pState = PlayerState.WEAPON;

                    // Make sure the weapon starts rotating according to the mouse cursor position
                    _controlledWeapon.shouldRotate = true;
                }
            }
        }
    }

	void Update () {
        // Check whether there has been an action (E), and 
        // whether the button as been lift up again
        if (_isActionPressed && Input.GetKeyUp(KeyCode.E))
        {
            _isActionPressed = false;
        }


        if (_pState == PlayerState.WALK)
        {

        }
        else if (_pState == PlayerState.WEAPON)
        {
            // Handle shooting input
            if (Input.GetMouseButton(0))
            {
                _controlledWeapon.Shoot();
            }

            // Add an option to leave a weapon
            if (!_isActionPressed && Input.GetKeyDown(KeyCode.E))
            {
                _isActionPressed = true;
                // Give player back movement controls

                _controlledWeapon.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                _pState = PlayerState.WALK;

                // Make sure the weapon does not rotate anymore 
                _controlledWeapon.shouldRotate = false;
            }
        }
        else
        {
            print("UNREGISTERED STATE!");
        }


	}

    void FixedUpdate()
    {
        if (_pState == PlayerState.WALK)
        {
            // Handle movement input
            _rb.velocity = new Vector3(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkSpeed, 0.8f), 0.0f, Mathf.Lerp(0, Input.GetAxis("Vertical") * walkSpeed, 0.8f));
        }
    }
}