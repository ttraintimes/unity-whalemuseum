using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private ObjectInteraction interact;
    public string newSceneName;

    public bool transitionTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
        interact = GetComponent<ObjectInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        if ((interact.triggered == true) && (transitionTriggered == false))
        {
            transitionTriggered = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);
            foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                g.SetActive(false);
            }
            Invoke("resetTrigger", 0.1f);
        }

    }

    void resetTrigger()
    {
        transitionTriggered = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newSceneName));
    }
}
