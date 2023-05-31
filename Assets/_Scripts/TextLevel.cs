using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextLevel : MonoBehaviour {
    private Text _textLevel;
    private void Start() {
        _textLevel = GetComponent<Text>();
        _textLevel.text = "Уровень " + (SceneManager.GetActiveScene().buildIndex + 1);
    }
}
