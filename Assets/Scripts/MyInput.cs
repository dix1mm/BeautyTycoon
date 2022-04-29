using UnityEngine;

public class MyInput : MonoBehaviour{
    private const string _floorLayer = "Floor";
    [SerializeField] private Player _player;
    private Camera _camera;
    private int _layer;

    private void Update(){
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layer))
            _player.MoveTo(hit.point);
    }

    private void Start(){
        _camera = Camera.main;
        _layer = 1 << LayerMask.NameToLayer(_floorLayer);
    }
}