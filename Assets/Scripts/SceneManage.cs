using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] int nextSceneIndex = 0;

    public void freezeScene()
    {
        Time.timeScale = 0.0f;
    }

    public void unfreezeScene()
    {
        Time.timeScale = 1.0f;
    }

    public void loadNextScene()
    {
        unfreezeScene();
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void reloadScene()
    {
        unfreezeScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
