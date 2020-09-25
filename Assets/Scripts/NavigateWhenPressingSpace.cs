using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateWhenPressingSpace : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}