using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffectBooster : BaseBooster
{
    [SerializeField]
    private BaseBallEffects ballEffect;

    override public void ApplyBooster(Padel lastHitPadel, Ball triggeredBall = null)
    {
        var ballEffectsManagerOnPadel = lastHitPadel.GetComponent<BallEffectsManager>();
        ballEffectsManagerOnPadel.AddBallEffects(ballEffect);

        if (triggeredBall == null) return;

        ballEffect.ApplyBallEffect(triggeredBall);
    }
}
