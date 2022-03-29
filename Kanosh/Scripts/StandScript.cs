using UnityEngine;
using UnityEngine.SceneManagement;

public class StandScript : MonoBehaviour, IClicked
{
    private int nextSceneToLoad;

    private void Start()
    {
        // Setting the var to a scene index thats incremented
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void onClickAction()
    {
        // When Clicked load the next scene.
        SceneManager.LoadScene(nextSceneToLoad);
    }

    // Add GUI to indicate the Player has found the StandUser "Winner" etc. then next lvl
}
