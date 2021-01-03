using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BrickManager : NetworkBehaviour
{
    public BaseBooster m_booster;

    [SyncVar(hook = nameof(OnActiveChanged))]
    private bool m_isActive = true;

    public override void OnStartClient()
    {
        if (isServer) return;

        GetComponent<Collider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "mysteryBrick" && collision.gameObject.tag == "Ball")
        {

            //do destroy just set as inactive
            m_isActive = false;

            // Trigger any animations 


            //Award the player The boost
            CmdApplyBooster(collision.gameObject.GetComponent<Ball>().m_instigator);
            //   Debug.Log("Mystery Brick hit");
        }
        else if (gameObject.tag == "normalBrick" && collision.gameObject.tag == "Ball")
        {

            //do destroy just set as inactive
            m_isActive = false;

            // Trigger any animations


            //     Debug.Log("Brick hit");

        }
        
    }

    private void OnActiveChanged(bool isPreviouslyActive, bool isCurrentActive)
    {
        gameObject.SetActive(isCurrentActive);
    }
  
    [Server]
    void CmdApplyBooster(Padel p)
    {
        m_booster.ApplyBooster(p);
    }
}
