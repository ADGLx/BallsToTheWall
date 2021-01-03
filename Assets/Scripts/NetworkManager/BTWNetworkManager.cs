using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BTWNetworkManager : NetworkManager
{
    public List<Startpoint> m_startpoints = new List<Startpoint>();

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        var startpoint = GetAvailableStartPoint();
        if (startpoint == null) return;
        if (startpoint.m_attachedBoudary == null) return;

        GameObject player = Instantiate(playerPrefab, startpoint.transform.position, startpoint.transform.rotation);
        startpoint.m_padelSocket = player.GetComponent<Padel>();
        startpoint.m_attachedBoudary.SetupDefendingPadel(player.GetComponent<Padel>());

        NetworkServer.AddPlayerForConnection(conn, player);
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
