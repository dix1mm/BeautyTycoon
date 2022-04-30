using UnityEngine;
using UnityEngine.Events;

public class Swiper : MonoBehaviour{
    [SerializeField] private float _minXDistance;
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;
    private Vector2 _startPos;

    private void Update(){
        if (Input.GetMouseButtonDown(0)) startSwipe();
        if (Input.GetMouseButtonUp(0)) stopSwipe();
    }

    private void startSwipe() => _startPos = Input.mousePosition;

    private void stopSwipe(){
        Vector2 swipePath = (Vector2)Input.mousePosition - _startPos;
        if (swipePath.magnitude < _minXDistance) return;
        if (swipePath.x > 0) OnSwipeRight.Invoke();
        else OnSwipeLeft.Invoke();
    }
}