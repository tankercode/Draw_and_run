using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGroup : MonoBehaviour
{
    [SerializeField]
    public GM gm;

    [SerializeField]
    public Guard _gameUnit;

    [SerializeField]
    public int _unitsCount;

    [SerializeField]
    public drawer _drawerOnGO;

    [SerializeField]
    public float _startSplineFolloverSpeed = 0;

    public List<Guard> _units = new List<Guard>();

    public void GenNewUnits() {

        for (float x = 0; x < _unitsCount; x++) {
            _units.Add( Instantiate(_gameUnit, new Vector3(x / 10, 0, 0), Quaternion.identity));
        }

        foreach (var v in _units) {
            v.transform.parent = transform;
            v.guardDead.AddListener(gm.CheckGG);
        }

    }

    public void StartRunning() {

        foreach (var v in _units) {
            v.RunBoy();
        }

        transform.GetComponent<SplineFollower>().followSpeed = _startSplineFolloverSpeed;

    }

    public void StartDancing() {
        foreach (var v in _units)
        {
            if(v != null) v.DanceBoy();
        }
    }

    public void KILLEVERYONE() {
        if(_units.Count > 0)
        foreach (var v in _units) {
                if(v != null) Destroy(v.gameObject);
            }

        _units.Clear();
    }

    public void SetNewUnitsPosition() {
        int _index = 0;
        foreach (var unit in _units) {
            if (unit != null && _index < _drawerOnGO._points.Count) { 
                unit.transform.position = new Vector3(_drawerOnGO._points[_index].x, 0, _drawerOnGO._points[_index].y);

                _index++;
            }
            else _index = 0;
        }
    }

}
