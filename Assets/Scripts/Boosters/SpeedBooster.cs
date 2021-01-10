using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : BaseBooster
{
    public float speedPercentIncrease = 0.25f;
    private float OriginalSpeed;
    override public void ApplyBooster(Padel curPadel, Ball triggeredBall = null)
    {
        SimpleMovement c = curPadel.GetComponent<SimpleMovement>();
        OriginalSpeed = c.m_movingSpeed;
        c.m_movingSpeed += OriginalSpeed * speedPercentIncrease;
    }
}
