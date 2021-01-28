using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float time;
    void OnEnable()
    {
        Invoke(nameof(DisableMe),time);
    }

    private void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
