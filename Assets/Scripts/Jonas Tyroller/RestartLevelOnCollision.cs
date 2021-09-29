using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnCollision : MonoBehaviour
{
    [SerializeField]
    private string[] collisionTags;
    private void OnCollisionEnter(Collision collision)
    {
        if(CheckCollisions(collision.gameObject.tag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private bool CheckCollisions(string tag)
    {
        for (int i=0; i<collisionTags.Length; i++)
        {
            if (collisionTags[i] == tag)
            {
                return true;
            }
        }
        return false;
    }
}
