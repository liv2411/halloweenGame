using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    public AudioClip collisionSound;        // Sound to play on pickup
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Play sound if available
            if (collisionSound != null && audioSource != null)
                audioSource.PlayOneShot(collisionSound);

            // Destroy the collectible
            Destroy(other.gameObject);
        }
    }
}
