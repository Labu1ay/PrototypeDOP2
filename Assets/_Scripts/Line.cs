using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private EdgeCollider2D _collider;
    [HideInInspector] public float LineThickness;
    [SerializeField] private Transform _eraser;
    
    private readonly List<Vector2> _points = new List<Vector2>();

    void Start() {
        _lineRenderer.widthMultiplier = LineThickness;
        _collider.transform.position -= transform.position;
        if(_eraser) _eraser.localScale = Vector3.one * LineThickness / 2f;
    }
    private void Update() {
        if(_eraser == null) return;
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 eraserPosition = new Vector3(mousePos.x, mousePos.y, -0.2f);

        _eraser.position = eraserPosition;
    }
    public void SetPosition(Vector2 pos) {
        if (!CanAppend(pos)) return;

        _points.Add(pos);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, pos);

        _collider.points = _points.ToArray();
    }

    private bool CanAppend(Vector2 pos) {
        if (_lineRenderer.positionCount == 0) return true;

        return Vector2.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1), pos) > DrawController.RESOLUTION;
    }
}
