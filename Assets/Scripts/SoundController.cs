using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public List<AudioClip> WalkSounds;
    public AudioSource isMoving;
    public AudioSource isJumped;
    public AudioSource isLanded;
    public AudioSource isKnocked;
    public List<AudioClip> HitSounds;
    public AudioSource isHitedSound;
    public int pos;


    public void playWalking()
    {
        pos = (int)Mathf.Floor(Random.Range(0, WalkSounds.Count));
        isMoving.PlayOneShot(WalkSounds[pos]);
    }

    public void playJump()
    {
        isJumped.Play();
    }

    public void playLand()
    {
        isLanded.Play();
    }

    public void playKnock()
    {
        isKnocked.Play();
    }

    public void playHit()
    {
        pos = (int)Mathf.Floor(Random.Range(0, HitSounds.Count));
        isHitedSound.PlayOneShot(HitSounds[pos]);
    }
}
