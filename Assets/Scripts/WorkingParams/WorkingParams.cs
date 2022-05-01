using UnityEngine;
using UnityEngine.Events;

public class WorkingParams : MonoBehaviour{
    public UnityEvent<string> OnTimeChange;
    private WorkingTime _time;

    public IWorkingTime WorkingTime => _time;

    private void Awake() => _time = new WorkingTime();

    private void FixedUpdate(){
        _time.Update(Time.fixedDeltaTime);
        OnTimeChange.Invoke(_time.Time);
    }
}