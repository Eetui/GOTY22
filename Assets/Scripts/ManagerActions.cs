using UnityEngine;

public class ManagerActions : MonoBehaviour
{
    private GameManager gm;

    public GameState state;
    private void Start()
    {
        gm = GameManager.Instance;
    }

    [ContextMenu("Change State Action")]
    public void ChangeStateAction()
    {
        Debug.Log("ChangeStateAction", this);
        gm.SetState(state);
    }
}
