using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    private Coroutine _activateCorotineVolume;
    private Coroutine _deactivateCorotineVolume;

    private float _volume;
    private float _minVolume;
    private float _maxVolume;

    private void Start()
    {
        _sound.volume = 0;
    }

    public void PlaySound()
    {
        StopCoroutineBefore();
        _minVolume = _volume = 1f;
        _sound.Play();
        _activateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        StopCoroutineBefore();
        _maxVolume = _volume = 0f;
        StopCoroutine(_activateCorotineVolume);
        _activateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    private void StopCoroutineBefore()
    {
        if(_deactivateCorotineVolume != null)
        {
            StopCoroutine(_deactivateCorotineVolume);
        }

        _deactivateCorotineVolume = StartCoroutine(ChangeVolume());
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
