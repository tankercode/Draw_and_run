using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.Events;

public class drawer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField]
    public bool _followPlatform = false;

    [SerializeField]
    public UnityEvent _onDrawEnd;

    [SerializeField]
    public LineRenderer _lineRenderer;

    [SerializeField]
    public Camera _camera;

    [SerializeField]
    public Vector3 offset;

    private Ray _ray;

    public List<Vector3> _points = new List<Vector3>();
    public float _distanceBetweenPoints = 0.1f;

    private bool isDrawing = false;

    public Vector3 GetPositionRayOnObject()
    {
        /*_ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out RaycastHit _hitInfo))
        {
            return _hitInfo.point;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }*/
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _points.Clear();
        _points.Add(GetPositionRayOnObject());
        isDrawing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrawing = false;
        _onDrawEnd?.Invoke();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if(isDrawing)
        if (Vector3.Distance(_points[_points.Count-1], GetPositionRayOnObject()) > _distanceBetweenPoints) {
            
                _points.Add(GetPositionRayOnObject());

                _lineRenderer.positionCount = _points.Count;
                _lineRenderer.SetPositions(_points.ToArray());

            }
    }

    private void Update()
    {
        if (_followPlatform)
        {
            offset = transform.position;

            foreach (var p in _points) {
                p.Set(p.x + offset.x, p.y + offset.y, p.z+offset.z);
            }
        }
    }
}
