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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isAttached)
        { return;  }

        var distanceToPadel = gameObject.GetComponent<CircleCollider2D>().radius + m_instigator.GetComponent<BoxCollider2D>().size.y / 2;

        gameObject.transform.position = m_instigator.transform.position + distanceToPadel * m_instigator.GetVectorToCenter();
    }

    public void Fire()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = m_startingVelocity * new Vector2(1, 1);
    }
}
