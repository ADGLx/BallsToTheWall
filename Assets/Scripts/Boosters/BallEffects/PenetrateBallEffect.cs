﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrateBallEffect : BaseBallEffects
{
    public override void ApplyBallEffect(Ball ball)
    {
        ball.m_canPenetrate = true;
    }
}
