using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _entered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _exit?.Invoke();
    }
}
