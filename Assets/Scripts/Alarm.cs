using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    private Coroutine _activateCorotineVolume;

    private float _volume;

    private void Start()
    {
        _sound.volume = 0;
    }

    public void PlaySound()
    {
        _volume = 1f;
        _sound.Play();
        _activateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _volume = 0f;
        StopCoroutine(_activateCorotineVolume);
        _activateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        float movementVolume = 0.2f;

        while(_sound.volume != _volume)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, _volume, movementVolume * Time.deltaTime);

            yield return null;
        }
    }
}
