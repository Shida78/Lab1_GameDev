using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPanel : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }

        if (other.CompareTag("Win"))
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }

    public void restart(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(sceneName);
    }

    public void nextLVL(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
