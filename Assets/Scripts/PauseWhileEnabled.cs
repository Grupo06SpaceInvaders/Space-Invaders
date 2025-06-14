using UnityEngine;

public class PauseWhileEnabled : MonoBehaviour
{
    private float lastTimeScale = 1;

    private void OnEnable()
    {
        if  (Time.timeScale == 0) return;
        lastTimeScale = Time.timeScale;    
    }

    private void OnDisable()
    {
        if  (Time.timeScale == 0) return;
        Time.timeScale = lastTimeScale;
    }


}