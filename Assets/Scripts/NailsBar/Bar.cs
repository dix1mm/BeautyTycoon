using UnityEngine;
using UnityEngine.Events;
using CharacterStates;
using Client;

namespace NailsBar{
    public class Bar : MonoBehaviour{
        public UnityEvent OnProcessStart;
        public UnityEvent OnProcessEnd;
        private Character _worker;
        private Character _client;
        private bool isProcessing;

        public void WorkerEnter(Character worker){
            _worker = worker;
            tryStartProcess();
        }

        public void ClientEnter(Character client){
            _client = client;
            tryStartProcess();
        }

        public void WorkerExit(){
            _worker.StopProcessing();
            _worker = null;
            tryStopProcess();
        }        

        public void ClientExit(){
            _client.StopProcessing();
            _client = null;
            tryStopProcess();
        }

        public void AcceptCard(int cardNumber){//1-3
            if (_client.TryGetComponent(out TasteGenerator taste))
                taste.CheckTaste(cardNumber);
            if (_client.TryGetComponent(out Navigation navigation))
                navigation.MoveToExit();
        }

        private void tryStartProcess(){
            if (isProcessing) return;
            if ((_worker != null) && (_client != null)){
                isProcessing = true;
                _worker.StartProcessing();
                _client.StartProcessing();
                OnProcessStart.Invoke();
            }
        }

        private void tryStopProcess(){
            if (!isProcessing) return;
            if ((_worker == null) || (_client == null)){
                isProcessing = false;
                _worker?.StopProcessing();
                _client?.StopProcessing();
                OnProcessEnd.Invoke();
            }
        }
    }
}