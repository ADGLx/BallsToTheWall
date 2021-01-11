using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Padel : NetworkBehaviour
{
    private Vector3 m_ankerPosition = Vector3.zero;
    public Quaternion m_startingRotation;
    [SyncVar] //Keeps this in sync with the server
    public int PlayerIndex;

    [SyncVar(hook = nameof(OnPadelActivityChanged))]
    public bool m_isActive = true;

    [SyncVar (hook = nameof(SetLength))] //this calls SetLength when the variable changes
    public float m_padelLength = 1f;

    public GameObject m_ball;
    public GameObject m_intantiatedBall;


    void Awake()
    {
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, m_ankerPosition - gameObject.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_startingRotation = gameObject.transform.rotation;
        SpawnBall();

    }

    public override void OnStopClient()
    {
        if (!isServer) return;
        ServerCleanup();
    }

    public Vector3 GetVectorToCenter()
    {
        return (m_ankerPosition - gameObject.transform.position).normalized;
    }

    [Command]
    public void FireBall()
    {
        if (m_intantiatedBall == null)
        { return; }

        var ballComp = m_intantiatedBall.GetComponent<Ball>();

        ballComp.m_isAttached = false;
        ballComp.Fire();

        m_intantiatedBall = null;
    }

    [Command]
    void SpawnBall()
    {
        m_intantiatedBall = Instantiate(m_ball);
        NetworkServer.Spawn(m_intantiatedBall);
        var ballComp = m_intantiatedBall.GetComponent<Ball>();

        ballComp.m_instigator = this;
        ballComp.m_isAttached = true;
    }

    [Server]
    private void ServerCleanup()
    {
        if (m_intantiatedBall == null)
        { return; }

        NetworkServer.Destroy(m_intantiatedBall);
    }

    private void OnPadelActivityChanged(bool activePrevious, bool activeCurrent)
    {
        if (activeCurrent) return;

        this.gameObject.SetActive(false);

        ServerCleanup();
    }

    void SetLength(float oldV, float newV)
    {
        this.transform.localScale = new Vector2(newV, 1);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ball") return;

        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball.m_instigator == this) return;

        GetComponent<BallEffectsManager>().ReplaceBallEffect(ball,ball.m_instigator);


        ball.m_instigator = this;
    }

}
