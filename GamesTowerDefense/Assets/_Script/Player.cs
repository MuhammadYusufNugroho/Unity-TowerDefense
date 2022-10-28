using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public ParticleSystem vfx;

    private void Awake()
    {
        vfx = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            vfx.Play();
        }
    }
}
