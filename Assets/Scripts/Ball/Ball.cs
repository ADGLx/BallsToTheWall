using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ball : NetworkBehaviour
{
    public Padel m_instigator;
    public bool m_canPenetrate = false;

    [SyncVar]
    public bool m_isAttached = false;
    [SyncVar]
    public float m_startingVelocity;

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
        if (!isServer) return;

        if (m_instigator == null) return;

        if (m_isAttached)
        {
            var distanceToPadel = GetComponent<CircleCollider2D>().radius + m_instigator.GetComponent<BoxCollider2D>().size.y / 2;
            gameObject.transform.position = m_instigator.transform.position + distanceToPadel * m_instigator.GetVectorToCenter();
        }
    }

    private void FixedUpdate()
    {
        LimitBallVelocity();
    }

    public void Fire()
    {
        //This points it towards the middle always 
        rb.velocity = m_startingVelocity * (Vector2.zero - new Vector2(transform.position.x, transform.position.y));
    }

    public void LimitBallVelocity()
    {
        if(rb.velocity.magnitude > m_velocitylimit)
        rb.AddForce(new Vector2(-rb.velocity.x, -rb.velocity.y)); //This kinda woks 
    }
}




