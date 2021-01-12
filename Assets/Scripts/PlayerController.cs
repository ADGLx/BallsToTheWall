using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    void Start()
    {
        if (!isLocalPlayer)
        { return; }
    }

    public override void OnStartClient()
    {
        GameState.AddPlayer(gameObject);
        base.OnStartClient();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        GameState.AllignCameraWithPlayer(gameObject);
    }

    public class InputKeys //easier to change to the input in unity
    {
        public string HORIZONTAL = "Horizontal";
        public string SPACE = "Jump"; 
    }
    public InputKeys Key = new InputKeys();

   //The actual input
    [HideInInspector]
    public float horizontal;

    [HideInInspector]
    public bool space;

    void GetInput()
    {
        horizontal = Input.GetAxis(Key.HORIZONTAL);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        { return; }

        var axisHorizontal = Input.GetAxis(Key.HORIZONTAL);
        if (axisHorizontal != 0)
        {
            gameObject.GetComponent<SimpleMovement>().HandleMoveHorizontal(axisHorizontal);
        }

        if (Input.GetButton(Key.SPACE))
        {
            gameObject.GetComponent<Padel>().FireBall();
        }
    }
}
