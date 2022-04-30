using UnityEngine;
using UnityEngine.UI;
using NailsBar;

[RequireComponent(typeof(Image))]
public class CardSwiper : MonoBehaviour{
    [SerializeField] private Sprite[] _cards;
    [SerializeField] private Bar _bar;
    private int _currCardIndex;
    private Image _image;

    public void Next(){
        _currCardIndex--;
        if (_currCardIndex < 0)
            _currCardIndex = _cards.Length-1;
        _image.sprite = _cards[_currCardIndex];
    }

    public void Accept() => _bar.AcceptCard(_currCardIndex+1);

    private void Awake() => _image = GetComponent<Image>();
}