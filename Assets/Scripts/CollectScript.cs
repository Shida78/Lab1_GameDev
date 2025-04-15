using UnityEngine;
using UnityEngine.Events;

public class CollectScript : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0f, 360f)]
    [SerializeField] float rotationSpeed = 70;

    [Header("Events")]
    public UnityEvent OnPlayerEnter;            //событие при пересечении объекта и игрока

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(transform.up, Random.Range(0, 180));   //поворот на старте
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnter?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
