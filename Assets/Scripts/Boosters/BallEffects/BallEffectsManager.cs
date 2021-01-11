using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallEffectsManager : NetworkBehaviour
{
    public List<BaseBallEffects> m_ballEffects = new List<BaseBallEffects>();

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


    public void ReplaceBallEffect(Ball ball, Padel prevInstigator)
    {
        if(prevInstigator != null)
        {
            foreach (var ballEffect in prevInstigator.GetComponent<BallEffectsManager>().m_ballEffects)
            {
                ballEffect.RevertBallEffect(ball);
            }
        }

        foreach (var ballEffect in m_ballEffects)
        {
            ballEffect.ApplyBallEffect(ball);
        }
    }
}
