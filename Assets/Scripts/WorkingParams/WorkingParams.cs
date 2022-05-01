using UnityEngine;

public class WorkingParams : MonoBehaviour{
    private WorkingTime _time;

    public IWorkingTime WorkingTime => _time;

    private void Awake() => _time = new WorkingTime();

    private void FixedUpdate() => _time.Update(Time.fixedTime);
}