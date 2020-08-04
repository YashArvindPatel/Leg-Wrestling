using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public float setTimer = 0.2f;
    private float timer;

    private void OnEnable()
    {
        timer = setTimer;
    }

    private void Update()
    {
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
