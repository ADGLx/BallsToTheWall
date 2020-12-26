﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Padel : NetworkBehaviour
{
    private Vector3 m_ankerPosition = Vector3.zero;
    public Quaternion m_startingRotation;
   [SyncVar] //Keeps this in sync with the server
    public int PlayerIndex;
    [SyncVar]
    public bool m_isActive = true;

    public GameObject m_ball;
    public GameObject m_intantiatedBall;



    void Awake()
    {
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, m_ankerPosition - gameObject.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_startingRotation = gameObject.transform.rotation;
        SpawnBall();
        CmdGetBoundary();


    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isActive)
            this.gameObject.SetActive(false);
    }

    public Vector3 GetVectorToCenter()
    {
        return (m_ankerPosition - gameObject.transform.position).normalized;
    }

    [Command]
    public void FireBall()
    {
        if (m_intantiatedBall == null)
        { return; }

        var ballComp = m_intantiatedBall.GetComponent<Ball>();

        ballComp.m_isAttached = false;
        ballComp.Fire();

        m_intantiatedBall = null;
    }

    [Command]
    void SpawnBall()
    {
        m_intantiatedBall = Instantiate(m_ball);
        NetworkServer.Spawn(m_intantiatedBall);
        var ballComp = m_intantiatedBall.GetComponent<Ball>();



        ballComp.m_instigator = this;
        ballComp.m_isAttached = true;
    }

    [Command]
    void CmdGetBoundary()
    {
        GameObject BoundaryH = GameObject.FindGameObjectWithTag("Boundary");

        if (BoundaryH == null)
        {
            Debug.LogError("Boundary Not Found");
            return;
        }

        BoundaryH.GetComponent<BoundaryManager>().AddPlayer(this);


    }


}
