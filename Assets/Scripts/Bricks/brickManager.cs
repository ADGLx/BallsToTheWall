using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class brickManager : NetworkBehaviour
{
    public Type t;
    private BaseBooster baseBooster;
    public BoostersTypes m_booster = BoostersTypes.None;
    // Start is called before the first frame update
    void Awake()
    {
        InitializeBoosterType();
    }

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
                gameObject.SetActive(true);

                // Trigger any animations


           //     Debug.Log("Brick hit");

        }
        
    }

    //Pairs the enums with the actual class method, I dont like the way it works but unity does not support the drag and drop in the inspector)
    void InitializeBoosterType()
    {
        switch(m_booster)
        {
            case BoostersTypes.SpeedBoost:
                baseBooster = new SpeedBooster();
                break;

            case BoostersTypes.LengthBoost:
                baseBooster = new LengthBooster();
                break;
            
            case BoostersTypes.None:
                baseBooster = null;
                break;

            default:
                Debug.LogWarning("Remember to add a case in this switch!");
                baseBooster = null;
                break;
        }
    }
  
    [Server]
    void CmdApplyBooster(Padel p)
    {
        baseBooster.ApplyBooster(p);
    }
}

public enum BoostersTypes {SpeedBoost, LengthBoost, None };