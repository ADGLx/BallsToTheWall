using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BoundaryManager : NetworkBehaviour
{
    public Padel m_defendingPadel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            CmdLose(m_defendingPadel, collision.GetComponent<Ball>());
        }
    }

    void CmdLose(Padel padel, Ball ball)
    {
        GetComponent<Collider2D>().isTrigger = false;
        if (padel == null) return;
        //This turns off the padels on the client and the sv
        padel.m_isActive = false;
        padel.gameObject.SetActive(false);
        NetworkServer.Destroy(ball.gameObject);

        Debug.Log(m_defendingPadel.name + " lost");
    }

    public void SetupDefendingPadel(Padel defendingPadel)
    {
        if (defendingPadel == null) return;

        m_defendingPadel = defendingPadel;
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void Cleanup()
    {
        m_defendingPadel = null;
        GetComponent<Collider2D>().isTrigger = false;
    }
}
