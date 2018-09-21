using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float fSpeed;
    public GameObject Parent;
	// Use this for initialization
	void Start () {
        Rigidbody m_Rigidbody = GetComponent(typeof(Rigidbody)) as Rigidbody;
        Transform m_Transform = GetComponent(typeof(Transform)) as Transform;
        m_Rigidbody.velocity = m_Transform.forward * fSpeed;

        if( Parent != null )
        {
            Rigidbody ParentBody = Parent.GetComponent(typeof(Rigidbody)) as Rigidbody;
            m_Rigidbody.velocity += ParentBody.velocity;
        }
        else
        {
            m_Rigidbody.velocity = m_Transform.forward * fSpeed;
        }
    }
   

}
