using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptSound : MonoBehaviour
{
    private Musica musica;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    // Start is called before the first frame update
    void Start()
    {
        musica = GameObject.FindObjectOfType<Musica>();
        UpdateIconVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseMusic()
    {
        musica.ToggleSound();
        UpdateIconVolume();
    }
    void UpdateIconVolume()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;

        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}
