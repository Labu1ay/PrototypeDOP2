using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityTrigger : MonoBehaviour {
    [HideInInspector] public bool IsVisible;
    private void OnTriggerEnter2D(Collider2D other) => IsVisible = true;
}
