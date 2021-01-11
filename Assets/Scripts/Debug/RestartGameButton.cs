using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class RestartGameButton : NetworkBehaviour
{
    public GameObject Button;
    //This will only happen for the server player

    public override void OnStartClient()
    {
        if(NetworkServer.connections.Count==1)//if its the first player to join the server
        {
            CreateOnClient();
        }
        base.OnStartClient();
    }

    private void CreateOnClient()
    {
       GameObject button = Instantiate(Button, GameObject.FindGameObjectWithTag("MainCamera").transform);
        button.GetComponentInChildren<Button>().onClick.AddListener(PressButton);
    }

    public void PressButton()
    {
        GameState.RestartGame();
    }
}
