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
    public int MaxHealth { get; set; } = 5;
    public int Health { get; set; }

    [SerializeField] private TextUpdater healthText;
    [SerializeField] private TextUpdater pointsText;

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
        
        ResetGame();
    }
    
    public void ResetGame()
    {
        Health = MaxHealth;
        Points = 0;

        healthText.UpdateText(Instance.Health.ToString());
        pointsText.UpdateText(Instance.Points.ToString());
        
        PlatformManager.Instance.ResetSpeed();
        PlatformManager.Instance.ResetClouds();
    }

    private void EndGame()
    {
        SetState(GameState.GameOver);
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
    
    public void TakeDamage()
    {
        FindObjectOfType<AudioManager>().Play("DamageSound");
        Instance.Health--;
        
        if (Instance.Health <= 0)
        {
            EndGame();
        }
        
        PlatformManager.Instance.ChangeSpeed(-0.08f);
        healthText.UpdateText(Instance.Health.ToString());
    }

    public void ScorePoints()
    {
        FindObjectOfType<AudioManager>().Play("PointSound");
        PlatformManager.Instance.ChangeSpeed(0.02f);
        Instance.Points += 10;
        
        pointsText.UpdateText(Instance.Points.ToString());
    }
}