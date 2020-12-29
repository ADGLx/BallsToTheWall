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

    public float m_velocitylimit = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!m_isActive) //should be active both in sv and client
            this.gameObject.SetActive(false);

        if (!m_isAttached)
        { return;  }

        if(!isServer)//only checks this if its the sv
        { return; }

        var distanceToPadel = GetComponent<CircleCollider2D>().radius + m_instigator.GetComponent<BoxCollider2D>().size.y / 2;
        gameObject.transform.position = m_instigator.transform.position + distanceToPadel * m_instigator.GetVectorToCenter();
    }

    private void FixedUpdate()
    {
        LimitBallVelocity();
    }

    public void Fire()
    {
        //This points it towards the middle always 
        rb.velocity = m_startingVelocity * (new Vector2(this.transform.position.x,this.transform.position.y) - Vector2.zero);
    }

    public void LimitBallVelocity()
    {
            if(rb.velocity.magnitude > m_velocitylimit)
            rb.AddForce(new Vector2(-rb.velocity.x, -rb.velocity.y)); //This kinda woks 
  

    }
}
