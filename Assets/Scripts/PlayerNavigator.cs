using UnityEngine;
using CharacterStates;

[RequireComponent(typeof(Character))]
public class PlayerNavigator : MonoBehaviour{
    private const string _floorLayer = "Floor";
    private Character _player;
    private Camera _camera;
    private int _layer;

    public void MovePlayer(){
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layer))
            _player.MoveTo(hit.point);
    }

    private void Awake(){
        _camera = Camera.main;
        _layer = 1 << LayerMask.NameToLayer(_floorLayer);
        _player = GetComponent<Character>();
    }
}