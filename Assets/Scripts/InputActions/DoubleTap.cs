using UnityEngine;
using UnityEngine.Events;

public class DoubleTap : MonoBehaviour{
    [SerializeField] private float _maxDelay;
    public UnityEvent OnTrigger;
    private float _lastTapTime;

    private void Update(){
        if (!Input.GetMouseButtonDown(0)) return;
        if (Time.time <= _lastTapTime + _maxDelay)
            OnTrigger.Invoke();
        _lastTapTime = Time.time;
    }
}