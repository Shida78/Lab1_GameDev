using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private TMP_Text ResultTimerText;
    [SerializeField] private int delta = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_TimerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
        StartCoroutine(ITimer());
    }

    IEnumerator ITimer()
    {
        while (true)
        { 
            if (sec == 59)
            {
                min++;
                sec = -1;
            }

            sec += delta;
            TimerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
    public void resultTime (int min, int sec)    //обновление информации о собранных объектах
    {
        ResultTimerText.text = "Затраченное время = " + min.ToString() + ":" + sec.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ResultTimerText.text = "Затраченное время = " + min.ToString("D2") + ":" + sec.ToString("D2");
    }
}
