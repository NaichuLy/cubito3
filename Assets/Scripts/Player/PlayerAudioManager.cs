using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource interactionSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip grabClip;
    [SerializeField] private AudioClip coinClip;

    public static PlayerAudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void PlayJumpSound()
    {
        if (interactionSource && jumpClip)
            interactionSource.PlayOneShot(jumpClip);
    }

    public void PlayGrabSound()
    {
        if (interactionSource && grabClip)
            interactionSource.PlayOneShot(grabClip);
    }

    public void PlayCoinSound()
    {
        if (interactionSource && coinClip)
            interactionSource.PlayOneShot(coinClip);
    }

}

