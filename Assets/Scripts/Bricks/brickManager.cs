using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class BrickManager : NetworkBehaviour
{
    public BaseBooster baseBooster;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "mysteryBrick" && collision.gameObject.tag == "Ball")
        {

                //do destroy just set as inactive
                gameObject.SetActive(false);

                // Trigger any animations 


                //Award the player The boost
                CmdApplyBooster(collision.gameObject.GetComponent<Ball>().m_instigator);
             //   Debug.Log("Mystery Brick hit");
        }
        else if (gameObject.tag == "normalBrick" && collision.gameObject.tag == "Ball")
        {

                //do destroy just set as inactive
                gameObject.SetActive(false);

                // Trigger any animations


           //     Debug.Log("Brick hit");

        }
        
    }
  
    [Server]
    void CmdApplyBooster(Padel p)
    {
        baseBooster.ApplyBooster(p);
    }
}
