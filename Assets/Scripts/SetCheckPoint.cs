using UnityEngine;

public class SetCheckPoint : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject selfObject;

    public AudioSource audioSource;
    public AudioClip checkPointSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(checkPointSound);
            respawnPoint.transform.position = other.transform.position;
        }
    }
}
