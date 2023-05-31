using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIController : MonoBehaviour {
    [SerializeField] private UnityEvent _levelComplete;
    private void OnEnable() => GameController.LevelCompleted += StartLevelCopleteEvent;
    private void StartLevelCopleteEvent() => _levelComplete.Invoke();
    public void NextLevel(int index) => SceneManager.LoadScene(index);
    private void OnDisable() => GameController.LevelCompleted -= StartLevelCopleteEvent;
}
