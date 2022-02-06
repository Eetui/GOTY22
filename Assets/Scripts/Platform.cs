using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float Speed { get; set; }
    public bool Move { get; set; }

    private Vector3 startPos;

    public void Awake()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (!Move) return;
        transform.Translate(-Vector3.forward * Speed);
    }

    private void OnEnable()
    {
        PlatformManager.Instance.Platforms.Add(this);
    }

    private void OnDisable()
    {
        PlatformManager.Instance.Platforms.Remove(this);
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}