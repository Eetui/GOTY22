using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;

    [SerializeField] private float startSpeed;
    
    public List<Platform> Platforms = new List<Platform>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        if (state == GameState.Game)
        {
            StartPlatforms();
        }
        else
        {
            StopPlatforms();
        }
    }

    private void StartPlatforms()
    {
        foreach (var plat in Platforms)
        {
            plat.Speed = startSpeed;
            plat.Move = true;
        }
    }

    private void StopPlatforms()
    {
        foreach (var plat in Platforms)
        {
            plat.Move = false;
        }
    }

    public void ChangeSpeed(float speedChange)
    {
        if (Platforms[0].Speed + speedChange <= startSpeed) return;

        foreach (var plat in Platforms)
        {
            plat.Speed += speedChange;
        }
    }
}
