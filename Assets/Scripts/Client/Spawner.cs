using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Client{
    public class Spawner : MonoBehaviour{
        [SerializeField] private Transform _bar;
        [SerializeField] private Transform _exit;    
        [SerializeField] private Navigation _client;
        [SerializeField] private int _maxCount;
        [SerializeField] private float _cd;
        public UnityEvent OnSuccessClient;
        public UnityEvent OnFailedClient;
        private int _currCount;
        private bool _spawning;
        private List<Navigation> _clients = new List<Navigation>();

        private void FixedUpdate(){
            if (_spawning) return;
            if (_currCount < _maxCount){
                StartCoroutine(spawn());
                _currCount++;
                _spawning = true;
            }
        }

        private IEnumerator spawn(){
            yield return new WaitForSeconds(_cd);
            Navigation client = Instantiate(_client, transform.position, transform.rotation);
            setupClient(client);
            _clients.Add(_client);
            _spawning = false;
        }

        private void setupClient(Navigation client){
            client.BarPos = _bar.position;
            client.ExitPos = _exit.position;
            client.OnExit.AddListener(clientExit);
            client.MoveToBar();
            if (client.TryGetComponent(out TasteGenerator taste)){
                taste.OnCorrectChoice.AddListener(clientSuccess);
                taste.OnIncorrectChoice.AddListener(clientFail);
            }
        }

        private void clientExit(Navigation client){
            _clients.Remove(client);
            _currCount--;
        }

        private void clientSuccess() => OnSuccessClient.Invoke();

        private void clientFail() => OnFailedClient.Invoke();
    }
}