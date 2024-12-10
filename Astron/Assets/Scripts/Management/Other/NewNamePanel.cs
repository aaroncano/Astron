using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewNamePanel : MonoBehaviour
{
    public TextMeshProUGUI InputName;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Highscore");
    }

    public void OkButton()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        string Name = InputName.text;
        gameObject.SetActive(false);
        FindObjectOfType<HighScoreTable>().UpdateNewName(Name);
    }
}
