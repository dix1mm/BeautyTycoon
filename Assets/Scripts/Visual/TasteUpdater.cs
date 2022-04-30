using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TasteUpdater : MonoBehaviour{
    private Text _text;

    public void UpdateTaste(int taste) => _text.text = taste.ToString();

    private void Awake() => _text = GetComponent<Text>();
}