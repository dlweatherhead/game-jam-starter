using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelWithButton : MonoBehaviour
{
    [SerializeField] KeyCode restartKey;

    void Update()
    {
        if(Input.GetKey(restartKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
