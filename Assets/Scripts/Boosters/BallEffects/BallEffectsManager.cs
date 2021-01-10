using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallEffectsManager : NetworkBehaviour
{
    private List<BaseBallEffects> m_ballEffects = new List<BaseBallEffects>();

    public override void OnStartLocalPlayer()
    {
        if (isServer) return;

        enabled = false;
    }

    public void AddBallEffects(BaseBallEffects ballEffect)
    {
        m_ballEffects.Add(ballEffect);
    }

    public void OnDestroy()
    {
        m_ballEffects.Clear();
    }

    private void ResetBallToDefault()
    {
        GetComponent<Ball>().m_canPenetrate = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ball") return;

        ResetBallToDefault();

        foreach (var ballEffect in m_ballEffects)
        {
            ballEffect.ApplyBallEffect(collision.gameObject.GetComponent<Ball>());
        }
    }
}
