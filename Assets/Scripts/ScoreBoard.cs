using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    public float lifeTime = 60f;
    private float gameTime;

    [Header("Events")]
    public UnityEvent onCollectAll;

    int collectCount = 4;
    int collected = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CollectScript[] collectables = Object.FindObjectsByType<CollectScript>(FindObjectsSortMode.None);
        collectCount = collectables.Length;

        foreach (CollectScript elem in collectables)
            elem.OnPlayerEnter.AddListener(onCollect);
    }

    public void onCollect()
    {
        if (collected >= collectCount) return;

        collected++;
        updateScoreText(collected, collectCount);

        if (collected >= collectCount)
            onCollectAll?.Invoke();
    }

    public void updateScoreText(int collected, int collectCount)    //обновление информации о собранных объектах
    {
        scoreText.text = "Объектов собрано" + collected.ToString() + "/" + collectCount.ToString();
    }

    void Update()
    {
        
    }
}
