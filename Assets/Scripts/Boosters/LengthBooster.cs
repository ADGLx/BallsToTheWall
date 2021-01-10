using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthBooster : BaseBooster
{
    public float LenghtAmout = 0.25f;
    private float prevLenght;

    override public void ApplyBooster(Padel curPadel, Ball triggeredBall = null)
    {
        prevLenght = curPadel.m_padelLength;
        curPadel.m_padelLength += LenghtAmout; 
    }
}
