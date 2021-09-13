using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPause = false;
    
    public void pauseGame()
    {
        if (isPause){
            Time.timeScale = 1;
            isPause = false;
        } else {
            Time.timeScale = 0;
            isPause = true;
        }
    }
}
