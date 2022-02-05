using System;
using UnityEngine;

public class ComponentToggler : MonoBehaviour
{

    [SerializeField] private PlayerInput player;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        if (state == GameState.Game)
        {
            player.enabled = true;
        }
        else
        {
            player.enabled = false;
        }
        Debug.Log($"Setting player active: {player.enabled}", this);
    }
}
