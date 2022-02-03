using System;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Platform platform))
        {
            ResetPosition(platform);
        }
    }
    private void ResetPosition(Platform platform)
    {
        var pos = platform.transform.position;
        platform.transform.position = new Vector3(
            pos.x,
            pos.y,
            pos.z + platforms.Length * (platforms[0].transform.lossyScale.z * 10));
    }
}
