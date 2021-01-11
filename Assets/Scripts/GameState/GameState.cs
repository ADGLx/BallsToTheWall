using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameState : NetworkBehaviour
{
    public static List<GameObject> m_players = new List<GameObject>();

    //public static GameState singleton { get; private set; }

    //void Awake()
    //{
    //    // Don't allow collision-destroyed second instance to continue.
    //    InitializeSingleton();
    //}

    //void InitializeSingleton()
    //{
    //    if (singleton != null && singleton == this) return;

    //    singleton = this;
    //    enabled = true;
    //}

    public static void AddPlayer(GameObject playerObject)
    {
        m_players.Add(playerObject);
    }

    public static void RemovePlayer(GameObject playerObject)
    {
        if (!m_players.Contains(playerObject))
        { return; }

        m_players.Remove(playerObject);

    }

    public static void AllignCameraWithPlayer(GameObject playerObject)
    {
        var sceneCamera = Camera.main;
        if (sceneCamera == null || playerObject == null) return;
        sceneCamera.transform.RotateAround(Vector3.zero, Vector3.forward,
                playerObject.transform.rotation.eulerAngles.z - sceneCamera.transform.rotation.eulerAngles.z);
    }

    [Server]
    public static void RestartGame()
    {
       //Do all the restarting manually
    }

}
