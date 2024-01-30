using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private float remainingTime;
    IEnumerator End()
    {
        float elapsedTime = 0;
        while(elapsedTime < 3.0f){
            yield return null;
            elapsedTime += Time.unscaledDeltaTime;
            float ratio = elapsedTime / 3.0f;
            Time.timeScale = Mathf.Lerp(1, 0, ratio);
        }

        Time.timeScale = 1;

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Player"){
            StartCoroutine(End());
        }
    }
    
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            StartCoroutine(End());
        }
    }
}
