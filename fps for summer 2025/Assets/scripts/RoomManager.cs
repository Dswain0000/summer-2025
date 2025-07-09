
using UnityEngine;
using Photon.Pun;
using Photon.Realtime; // Needed for RoomOptions, etc.

public class RoomManager : MonoBehaviourPunCallbacks {
    public GameObject playerPrefab;
    public Transform spawnPoint;
    private GameObject localPlayer;

    public override void OnJoinedRoom() {
        base.OnJoinedRoom();
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);

        if (spawnPoint == null || playerPrefab == null) {
            Debug.LogError($"Null references – spawnPoint: {spawnPoint}, playerPrefab: {playerPrefab}", this);
            return;
        }

        localPlayer = PhotonNetwork.Instantiate(
            playerPrefab.name,
            spawnPoint.position,
            Quaternion.identity
        );
        localPlayer.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
}

