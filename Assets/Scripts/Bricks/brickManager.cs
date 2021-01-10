using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BrickManager : NetworkBehaviour
{
    public BaseBooster m_booster;

    [SyncVar(hook = nameof(OnActiveChanged))]
    private bool m_isActive = true;

    public override void OnStartClient()
    {
        if (isServer) return;

        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Ball") return;

        //Award the player The boost
        var ballComponent = collider.GetComponent<Ball>();
        if (ballComponent == null) return;

        CmdApplyBooster(ballComponent.m_instigator, ballComponent);
        //   Debug.Log("Mystery Brick hit");

        if (ballComponent.m_canPenetrate)
        {
            NetworkServer.Destroy(gameObject);
            return;
        }

        var ballRigidBody = collider.GetComponent<Rigidbody2D>();
        if (ballRigidBody == null) return;

        var colliderBrick = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[1];
        int hitAmount = colliderBrick.Raycast(ballRigidBody.position, hits);
        if (hitAmount == 0) return;

        ballRigidBody.velocity = Vector2.Reflect(ballRigidBody.velocity, hits[0].normal);

        NetworkServer.Destroy(gameObject);
    }

    private void OnActiveChanged(bool isPreviouslyActive, bool isCurrentActive)
    {
        gameObject.SetActive(isCurrentActive);
    }
  
    [Server]
    void CmdApplyBooster(Padel p, Ball triggeredBall)
    {
        if (m_booster == null) return;

        m_booster.ApplyBooster(p, triggeredBall);
    }
}
