using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public Text nameText;
    public InputField playerName;
    public Button nameButton;
    public Button saunaButton;    //Add more buttons here for more games
                                  // Use this for initialization
    void Start() {
        nameButton.onClick.AddListener(AddName);
        saunaButton.onClick.AddListener(delegate{StartGame(1);});
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void AddName()
    {
        PlayerPrefs.SetString("Name", playerName.text);
        nameText.text = "Name Saved";
    }
    void StartGame(int index)
    {
        switch (index) {
            case 1:
                SceneManager.LoadScene(index);
                break;

            }
    }
}
