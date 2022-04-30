using UnityEngine;

public class ClientSpawner : MonoBehaviour{
    [SerializeField] private GameObject _clientPrefab;
    [SerializeField] private int _maxCount;
    [SerializeField] private float _cd;
}