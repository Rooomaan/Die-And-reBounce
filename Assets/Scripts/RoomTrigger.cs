using UnityEngine;
using Unity.Cinemachine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera roomCam;
    private static CinemachineCamera currentCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (currentCam != null) currentCam.Priority = 0;
        roomCam.Priority = 10;
        currentCam = roomCam;
    }
}
