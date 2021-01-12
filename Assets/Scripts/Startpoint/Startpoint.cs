using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Startpoint : MonoBehaviour
{
    public BoundaryManager m_attachedBoudary;
    public Padel m_padelSocket;

    private void Start()
    {
        var btwNetworkManager = (BTWNetworkManager)NetworkManager.singleton;
        btwNetworkManager.m_startpoints.Add(this);
    }

    private void OnDestroy()
    {
        var btwNetworkManager = (BTWNetworkManager)NetworkManager.singleton;
        if (btwNetworkManager.m_startpoints.Contains(this))
        {
            btwNetworkManager.m_startpoints.Remove(this);
        }
    }
}
