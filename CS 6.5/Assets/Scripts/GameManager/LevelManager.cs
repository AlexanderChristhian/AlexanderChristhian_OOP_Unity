using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Awake()
    {
        GameObject someObject = GameObject.Find("Camera");
        if (someObject != null)
        {
            someObject.SetActive(false);
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Trigger the animation
        animator.SetTrigger("End");

        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Load the new scene
        SceneManager.LoadSceneAsync(sceneName);

        // Optionally, reset player position after the scene is loaded
        Player.Instance.transform.position = new Vector3(0, -4.5f, 0);
        animator.SetTrigger("Start");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}