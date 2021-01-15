using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBallEffect : BaseBallEffects
{
    private float m_previousVelocity;
    [SerializeField]
    private float m_addedSpeedLimit = 0.0f;

    public override void ApplyBallEffect(Ball ball)
    {
        m_previousVelocity = ball.m_velocitylimit;
        ball.m_velocitylimit += m_addedSpeedLimit;
        ball.GetComponent<Rigidbody2D>().velocity *= 2.5f;
    }

    public override void RevertBallEffect(Ball ball)
    {
        ball.m_velocitylimit = m_previousVelocity;
    }
}
