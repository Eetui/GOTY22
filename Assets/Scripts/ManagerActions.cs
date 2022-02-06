using System;
using UnityEngine;

public class ManagerActions : MonoBehaviour
{
    private GameManager gm;

    public GameState state;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    
    public void ChangeStateAction()
    {
        gm.SetState(state);
    }

    public void ResetGame()
    {
        gm.ResetGame();
    }
}
