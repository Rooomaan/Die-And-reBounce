using System.Collections;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Animator animator;

    public AudioSource audioSource;
    public AudioClip bounceSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
                StartCoroutine(AnimDelay(1f));
                audioSource.PlayOneShot(bounceSound);
            }
        }
    }

    IEnumerator AnimDelay(float _time)
    {
        animator.SetBool("Bounce", true);
        yield return new WaitForSeconds(_time);
        animator.SetBool("Bounce", false);
    }
}
