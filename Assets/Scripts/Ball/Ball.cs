using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ball : NetworkBehaviour
{
    public Padel m_instigator;
    [SyncVar]
    public bool m_isAttached = false;
    [SyncVar]
    public float m_startingVelocity;
    [SyncVar]
    public bool m_isActive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isActive) //should be active both in sv and client
            this.gameObject.SetActive(false);

        if (!m_isAttached)
        { return;  }

        if(isServer)//only checks this if its the sv
        {
            var distanceToPadel = gameObject.GetComponent<CircleCollider2D>().radius + m_instigator.GetComponent<BoxCollider2D>().size.y / 2;

            gameObject.transform.position = m_instigator.transform.position + distanceToPadel * m_instigator.GetVectorToCenter();
        } else
        {
            //this is happening now, 
        }

   
    
    }

    public void Fire()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = m_startingVelocity * new Vector2(1, 1);
    }
}
