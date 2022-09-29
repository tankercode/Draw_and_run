using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrawerOnGO : MonoBehaviour
{

    [SerializeField]
    public UnityEvent _onDrawEnd;

    [SerializeField]
    public LineRenderer _lineRenderer;

    [SerializeField]
    public Camera _camera;

    public List<Vector3> _points = new List<Vector3>();
    public float _distanceBetweenPoints = 20.0f;
    private bool isDrawing = false;

    private Ray _ray;

    void OnMouseDown()
    {

        _points.Clear();
        _points.Add(GetPositionRayOnObject());
        isDrawing = true;
    }

    public Vector3 GetPositionRayOnObject() {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit _hitInfo))
        {
            return _hitInfo.point;
        }
        else {
            return new Vector3(0, 0, 0);
        }
    }

    void OnMouseDrag()
    {
        if (isDrawing)
            if (Vector3.Distance(_points[_points.Count - 1], GetPositionRayOnObject()) > _distanceBetweenPoints)
            {
                _points.Add(GetPositionRayOnObject());
            }
    }

    private void Update()
    {
        
        if (isDrawing)
        {
            foreach (var p in _points) { p.Set(p.x, p.y, p.z-transform.position.z); }

            _lineRenderer.positionCount = _points.Count;
            _lineRenderer.SetPositions(_points.ToArray());
        }
    }

    private void OnMouseUp()
    {
        isDrawing = false;
        _onDrawEnd?.Invoke();
    }

}
