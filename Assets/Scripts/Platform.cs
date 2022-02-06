using UnityEngine;

public class Platform : MonoBehaviour
{
    public float Speed { get; set; }
    public bool Move { get; set; }
    private void Update()
    {
        if (!Move) return;
        transform.Translate(-Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        Debug.Log(PlatformManager.Instance);
        PlatformManager.Instance.Platforms.Add(this);
    }

    private void OnDisable()
    {
        PlatformManager.Instance.Platforms.Remove(this);
    }
}