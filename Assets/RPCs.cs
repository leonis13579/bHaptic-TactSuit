using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCs : MonoBehaviourPunCallbacks
{
    private Dictionary<Player, bool> players = new Dictionary<Player, bool>();

    public override void OnCreatedRoom()
    {
        players.Add(PhotonNetwork.MasterClient, false);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Added " + newPlayer.ActorNumber);
            players.Add(newPlayer, false);
        }
    }

    [PunRPC]
    private void RPC_SendStatus(int playerId, bool status)
    {
        if (PhotonNetwork.MasterClient.ActorNumber == playerId)
        {
            foreach (Player player in players.Keys)
            {
                if (player.ActorNumber == playerId)
                {
                    players[player] = status;
                }
            }

            foreach (Player player in players.Keys)
            {
                Debug.Log(player.ActorNumber + "\n" + players[player]);
            }
        }
    }
}
