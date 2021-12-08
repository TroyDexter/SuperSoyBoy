using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    public GameObject playerDeathPrefab;
    public AudioClip deathClip;
    public Sprite hitSprite;

    private SpriteRenderer spriteRenderer;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.transform.tag == "Player") 
        {
            //determine if an AudioClip has been assigned to the script and that a valid Audio Source component exists.
            var audioSource = GetComponent<AudioSource>();
            if (audioSource != null && deathClip != null) 
            {
                audioSource.PlayOneShot(deathClip);
            }
            // Instantiate the playerDeathPrefab at the collision point and swap the sprite of the saw blade with the hitSprite version.
            Instantiate(playerDeathPrefab, coll.contacts[0].point, Quaternion.identity);
            spriteRenderer.sprite = hitSprite;
            // destroy the colliding object (the player).
            Destroy(coll.gameObject);
        }
    }
}
