using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LargeBallEffect : BaseBallEffects
{
    private Vector3 m_previousScale = Vector3.one;
    [SerializeField]
    private Vector3 m_enlargeScale = 3 * Vector3.one;

    public override void ApplyBallEffect(Ball ball)
    {
        _ = WaitToApplyBallEffect(ball); //Not sure how this works 
    }

    public override void RevertBallEffect(Ball ball)
    {
        ball.gameObject.transform.localScale = m_previousScale;
    }

    private async Task WaitToApplyBallEffect(Ball ball)
    {
        await Task.Delay(350);
        m_previousScale = ball.gameObject.transform.localScale;
        ball.gameObject.transform.localScale = m_enlargeScale;
    }
}
