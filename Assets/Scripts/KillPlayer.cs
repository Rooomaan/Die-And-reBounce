using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour
{
    public Transform respawnPoint;

    public GameObject trampoline;
    public MonoBehaviour playerMovement;
    public int maxTrampo = 3;
    public Animator animator;

    private bool isRunningAnimation = false;
    private static Queue<GameObject> trampolines = new Queue<GameObject>();

    public AudioSource audioSource;
    public AudioClip deathSound;
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isRunningAnimation)
        {
            audioSource.PlayOneShot(deathSound);
            isRunningAnimation = true;
            StartCoroutine(AnimDelay(1f, other));
        }
    }

    public void SpawnJump(Vector3 _position)
    {
        GameObject newTrampoline = Instantiate(trampoline, _position, Quaternion.identity);
        trampolines.Enqueue(newTrampoline);
        newTrampoline.tag = "Trampoline";

        while (trampolines.Count > maxTrampo)
        {
            GameObject oldest = trampolines.Dequeue();
            if (oldest != null) Destroy(oldest);
        }
    }
    IEnumerator AnimDelay(float _time, Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        Vector3 deathPosition = other.transform.position;

        if (playerMovement != null) {
            playerMovement.enabled = false;
        }
        if (rb != null){
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(_time);
        animator.SetBool("Dead", false);

        SpawnJump(other.transform.position);
        other.transform.position = GameObject.FindGameObjectWithTag("RespawnPoint").transform.position;
        if (rb != null){
            rb.simulated = true;
        }
        if (playerMovement != null){
            playerMovement.enabled = true;
        }
        isRunningAnimation = false;
    }
    
}
