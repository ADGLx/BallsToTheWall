using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Powers_Manager : NetworkBehaviour
{
    private List<Padel> m_allplayers = new List<Padel>();
    [Header("Enlarger Characteristics")]
    public float enlargerPercentAdd = 0.25f;
    public float enlargerTime = 5f;

    [Header("Speed Power Characteristics")]
    public float speedPercentAdd = 0.25f;
    public float speedTime = 5f;


    private void Start()
    {

    }


    public void AddPlayer(Padel padel)
    {
        m_allplayers.Add(padel);
       
    }

    IEnumerator Power_EnlargePadel(Padel G)
    {

        G.m_padelLength += enlargerPercentAdd;

        yield return new WaitForSeconds(enlargerTime);

        G.m_padelLength = 1;

    }

    IEnumerator Power_SpeedPadel(Padel G)
    {
        SimpleMovement movement =G.GetComponent<SimpleMovement>();

        float prevSpeed = movement.m_movingSpeed;
        movement.m_movingSpeed += prevSpeed * speedPercentAdd;

        yield return new WaitForSeconds(speedTime);

        movement.m_movingSpeed = prevSpeed;

    }


    //Debug Stuff
    IEnumerator PlayWithDelay()
    {

        yield return new WaitForSeconds(5f);

        StartCoroutine(Power_SpeedPadel(m_allplayers[1]));

    }


}



