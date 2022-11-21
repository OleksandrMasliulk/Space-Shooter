using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shot")]
    [SerializeField] private AudioClip _shotSFX;
    [SerializeField, Range(0f, 1f)] private float _shotSFXVolume;

    [Header("Hit")]
    [SerializeField] private AudioClip _hitSFX;
    [SerializeField, Range(0f, 1f)] private float _hitSFXVolume;

    [Header("Explosion")]
    [SerializeField] private AudioClip _explosionSFX;
    [SerializeField, Range(0f, 1f)] private float _explosionSFXVolume;

    public void PlayShotSFX()
    {
        PlayClip(_shotSFX, _shotSFXVolume);
    }

    public void PlayHitSFX()
    {
        PlayClip(_hitSFX, _hitSFXVolume);
    }

    public void PlayExplosionSFX()
    {
        PlayClip(_explosionSFX, _explosionSFXVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null)
            return;

        Vector3 cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
    }
}
