using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("RPC send");
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("RPC_SendStatus", RpcTarget.MasterClient, photonView.ControllerActorNr, true);
        }
    }
}
