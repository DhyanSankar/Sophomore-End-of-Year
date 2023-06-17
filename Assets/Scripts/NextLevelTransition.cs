using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{

    bool isCurrentlyColliding;

    void OnCollisionEnter(Collision col) {
        isCurrentlyColliding = true;
    }
 
    void OnCollisionExit(Collision col) {
        isCurrentlyColliding = false;
    }

    void Update()
    {
        // Press the space key to start coroutine
        if (isCurrentlyColliding)
        {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        
        Scene scene = SceneManager.GetActiveScene();
        string newName = "Scene" + (scene.name[5] - '0' + 1);
        Debug.Log(newName);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}