using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padel_Powers : MonoBehaviour
{
    public int number = 1;

    [Header("PowerUp Characteristics")]
    public Enlarger m_enlarger;
    public Speeder m_speeder;

    [Header("Ball PowerUps")]
    public MakeBallFaster m_makeballfaster;
    public MakeOpponentSlowerUponTouching m_makeopponentslowerupontouching;
    public MakeOpponentSmaller m_makesmaller;
    // public PowerUp m_powerUp = PowerUp.None;
    //public BallEffects m_ballEffects = BallEffects.None;
    private void Start()
    {
        m_enlarger = new Enlarger(this.gameObject); //This just initializes the Enlarger class
    }


    //They are just gonna be called up by the ball component
    private void Update()
    {
        //CheckForBallEffects();
        //CheckForPowerUp();
    }

    /*
    private void CheckForPowerUp()
    {
        switch(m_powerUp)
        {
            case PowerUp.Enlarger:
                
                break;
            case PowerUp.GetFaster:

                break;
            case PowerUp.None:

                break;
            default:
                Debug.LogError("Remember to enter the PowerUp new enum case");
                break;
        }
    }*/

    /*
    private void CheckForBallEffects()
    {
        switch (m_ballEffects)
        {
            case BallEffects.MakeBallFaster:

                break;
            case BallEffects.MakeOpponentSlower:

                break;
            case BallEffects.MakeOpponentSmaller:

                break;
            case BallEffects.None:

                break;
            default:
                Debug.LogError("Remember to enter the BallEffect new enum case");
                break;
        }
    }*/
}

[System.Serializable]
public class Enlarger
{
    public float enlargerAmount = 0.25f;
    private bool Activated = false;
    private GameObject gObj;
    public Enlarger(GameObject G) //Constructor
    {
        gObj = G;
    }

    public void SwitchOn() //This switches the power on and off
    {
        Activated = !Activated;
        gObj.transform.localScale = gObj.transform.localScale * enlargerAmount;
    }
    public void SwitchOff() //This switches the power on and off
    {
        Activated = !Activated;
        gObj.transform.localScale = new Vector3(1, 1, 1);
    }

}

[System.Serializable]
public class Speeder
{
    public float SpeedAmount = 0.25f;
    private bool Activated = false;
    private GameObject gObj;
    private float prevSpeed = 0;
    public Speeder(GameObject G)
    {
        gObj = G;
    }

    public void SwitchOn()
    {
        Activated = !Activated;

        prevSpeed = gObj.GetComponent<SimpleMovement>().m_movingSpeed;
        gObj.GetComponent<SimpleMovement>().m_movingSpeed += prevSpeed * SpeedAmount; 
    }

    public void SwitchOff()
    {
        Activated = !Activated;
        gObj.GetComponent<SimpleMovement>().m_movingSpeed = prevSpeed;
    }

}

//Ball effects
[System.Serializable]
public class MakeBallFaster
{

}

[System.Serializable]
public class MakeOpponentSlowerUponTouching
{

}

[System.Serializable]
public class MakeOpponentSmaller
{

}


