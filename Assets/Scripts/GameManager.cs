using System;
using System.Collections;
using UnityEngine;

public enum GameState
{
    Start,
    Game,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Coins { get; set; }
    public int Points { get; set; }

    [SerializeField] private CanvasGroup startScreen;
    [SerializeField] private CanvasGroup gameScreen;
    [SerializeField] private CanvasGroup gameOverScreen;

    public GameState CurrentState { get; private set; }

    public event Action<GameState> OnStateChanged;
    
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
        SetFirstState(GameState.Start);
        OnStateChanged?.Invoke(CurrentState);
    }

    public void SetState(GameState nextState)
    {
        if (nextState == CurrentState) return;

        StartCoroutine(FadeCanvasGroup(false, GetStateCanvasGroup(CurrentState), 1f, () =>
        {
            StartCoroutine(FadeCanvasGroup(true, GetStateCanvasGroup(nextState), 1f));
            CurrentState = nextState;
            OnStateChanged?.Invoke(CurrentState);
        }));
    }
    
    private void SetFirstState(GameState firstState)
    {

        StartCoroutine(FadeCanvasGroup(true, GetStateCanvasGroup(firstState), 1f));
    }

    private IEnumerator FadeCanvasGroup(bool activate, CanvasGroup group, float duration, Action callback = null)
    {
        if(activate) group.gameObject.SetActive(activate);
        
        group.interactable = activate;
        float time = 0;
        float startValue = group.alpha;
        float endValue = activate ? 1 : 0;

        while (time < duration)
        {
            group.alpha = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            
            yield return null;
        }
        
        group.alpha = endValue;
        if(!activate) group.gameObject.SetActive(activate);
        callback?.Invoke();
    }

    private CanvasGroup GetStateCanvasGroup(GameState state)
    {
        return state switch
        {
            GameState.Game => gameScreen,
            GameState.Start => startScreen,
            GameState.GameOver => gameOverScreen,
            _ => startScreen
        };
    }
}