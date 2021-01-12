using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ReloadSceneButtonHandler : NetworkBehaviour
{
    [Command]
    public void OnReloadSceneButtonPressed()
    {
        Debug.Log("hhhhhhhhhhhhhhhhhhh");
        NetworkManager.singleton.ServerChangeScene("Alvaro");
    }
}
