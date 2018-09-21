using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float fXMin, fXMax, fZMin, fZMax;
}
public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public float fSpeed;
    public float fTilt;
    public Boundary mBoundary;
    public GameObject shot;
    public Transform shotspawn;
    public float fireRate;
    private float nextFire;
    void FixedUpdate()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");
        Vector3 vMovement = new Vector3(fHorizontal, 0.0f, fVertical);
        vMovement *= fSpeed;
        Rigidbody m_Rigidbody = GetComponent(typeof(Rigidbody)) as Rigidbody;
        m_Rigidbody.velocity = vMovement;

        m_Rigidbody.position = new Vector3
            (
                Mathf.Clamp(m_Rigidbody.position.x, mBoundary.fXMin, mBoundary.fXMax),
                0.0f,
                Mathf.Clamp(m_Rigidbody.position.z, mBoundary.fZMin, mBoundary.fZMax)
            );

        m_Rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, m_Rigidbody.velocity.x * -fTilt);
    }

    void Update()
    {
        if( Input.GetButton("Fire1") && Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
        }
    }
}
