using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class GameControlSystem : NetworkBehaviour
{
    [SerializeField]
    private GameObject m_controlMenu;
    
    [SyncVar(hook = nameof(OnPlayerIndexChanged))]
    public int m_playerIndex = -1;

    private GameObject m_instantiatedMenu = null;

    public void CreateMenuOnClient()
    {
        m_instantiatedMenu = Instantiate(m_controlMenu, Camera.main.transform);
        m_instantiatedMenu.GetComponentInChildren<Button>().onClick.AddListener(OnReloadSceneButtonPressed);
    }

    private void OnPlayerIndexChanged(int prevIndex, int newIndex)
    {
        if (m_instantiatedMenu == null)
        {
            CreateMenuOnClient();
        }
    }

    private void OnDestroy()
    {
        Destroy(m_instantiatedMenu);
    }

    [Command]
    public void OnReloadSceneButtonPressed()
    {
        Debug.Log("hhhhhhhhhhhhhhhhhhh");

        GetComponent<NetworkIdentity>().connectionToClient.Disconnect();

        SceneManager.LoadSceneAsync("Alvaro");
        //NetworkManager.singleton.ServerChangeScene("Alvaro");
        SceneManager.sceneLoaded += OnSceneReloaded;
    }

    [Server]
    void OnSceneReloaded(Scene scene, LoadSceneMode mode)
    {
        NetworkServer.SpawnObjects();
    }
}
