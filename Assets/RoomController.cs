using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte roomSize = 4;
    [SerializeField]
    private List<Transform> startPositions = new List<Transform>();

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning("Failed to join a room.");
        CreateRoom();
    }

    private void CreateRoom()
    {

        int randomRoomNumber = Random.Range(0, 10);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = roomSize
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOptions);
        Debug.Log("Creating room" + randomRoomNumber + ".");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("Failed to creating room... trying again.");
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined to the " + PhotonNetwork.CurrentRoom.Name);
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Person"), new Vector3(0, 1, 0), Quaternion.identity);
        switch (player.GetComponent<PhotonView>().ViewID)
        {
            case 1001:
                if (startPositions.Count > 0)
                {
                    player.transform.position = startPositions[0].position;
                    player.transform.rotation = startPositions[0].rotation;
                }
                break;
            case 2001:
                if (startPositions.Count > 1)
                {
                    player.transform.position = startPositions[1].position;
                    player.transform.rotation = startPositions[1].rotation;
                }
                break;
            case 3001:
                if (startPositions.Count > 2)
                {
                    player.transform.position = startPositions[2].position;
                    player.transform.rotation = startPositions[2].rotation;
                }
                break;
            case 4001:
                if (startPositions.Count > 3)
                {
                    player.transform.position = startPositions[3].position;
                    player.transform.rotation = startPositions[3].rotation;
                }
                break;
        }
    }

    
}
