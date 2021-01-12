using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BTWNetworkManager : NetworkManager
{
    public List<Startpoint> m_startpoints = new List<Startpoint>();
    public List<GameObject> m_players = new List<GameObject>();

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        var startpoint = GetAvailableStartPoint();
        if (startpoint == null) return;
        if (startpoint.m_attachedBoudary == null) return;

        GameObject player = Instantiate(playerPrefab, startpoint.transform.position, startpoint.transform.rotation);
        startpoint.m_padelSocket = player.GetComponent<Padel>();
        startpoint.m_attachedBoudary.SetupDefendingPadel(player.GetComponent<Padel>());

        NetworkServer.AddPlayerForConnection(conn, player);
        m_players.Add(player);
        SyncPlayersIndex();
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        if (conn == null || conn.identity == null) return;

        var playerObject = conn.identity.gameObject;
        if (playerObject != null && m_players.Contains(playerObject))
        {
            m_players.Remove(playerObject);
            SyncPlayersIndex();
        }

        base.OnServerDisconnect(conn);
    }

    private void SyncPlayersIndex()
    {
        foreach (var player in m_players)
        {
            if (player == null) continue;

            var playerControlSystem = player.GetComponent<GameControlSystem>();
            if (playerControlSystem == null) continue;

            playerControlSystem.m_playerIndex = m_players.IndexOf(player);
        }
    }

    private Startpoint GetAvailableStartPoint()
    {
        foreach (Startpoint startpoint in m_startpoints)
        {
            if (startpoint.m_padelSocket != null) continue;

            return startpoint;
        }

        return null;
    }
}
