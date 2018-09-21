using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMover : MonoBehaviour {
    public Camera camera;
    public float speed;
    public float fTilt;
    public float fireRate;
    public GameObject shot;
    public Transform shotspawn;


    private Rigidbody rb;
    private float nextFire;
    private Vector3 destination;
    public Boundary boundary;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
        }
    }

    void FixedUpdate()
    {
        //Make sure a touch event is happening
        if (Input.GetMouseButton(0))
        {
            //Build a ray from the touched point
            //Ignores multiple touches after the first
            //Ray touchRay = camera.ScreenPointToRay(Input.GetTouch(0).position);
            Ray touchRay = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(touchRay, out hit))
            {
                MonoBehaviour.print("You touched a thing.");
                destination = hit.point;
                destination.y = transform.position.y;
            }
        }

        Vector3 movementVector = destination - transform.position;
        float distanceToDestination = movementVector.magnitude;
        movementVector.Normalize();
      
        rb.velocity = (movementVector * speed);
        if (distanceToDestination < 0.1)
        {
            rb.velocity *= 0;
        }

            rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.fXMin, boundary.fXMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.fZMin, boundary.fZMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -fTilt);
    }



}
