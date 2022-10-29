using System;
using TMPro;
using UnityEngine;

namespace Script.NPC
{
    public class NpcContext : MonoBehaviour
    {
        public NpcBaseState WaitingState { get; private set; }

        public NpcBaseState GiveState { get; private set; }

        public NpcBaseState CompletedState { get; private set; }

        private NpcBaseState currentState;

        [SerializeField] private GameObject dialogueBox;

        [TextArea(3,10)]
        [SerializeField] private string taskText;
        [TextArea(3,10)]
        [SerializeField] private string waitingText;
        [TextArea(3,10)]
        [SerializeField] private string completedText;

        [SerializeField] private GameObject uiHint;

        [SerializeField] private GameObject uiDialog;
        private bool isPlayerNear;

        public GameObject UiDialog { get=>uiDialog; private set=>uiDialog=value; }

        public string TaskText { get=>taskText; private set=>taskText=value; }

        public string WaitingText { get=>waitingText; private set=>waitingText=value; }

        public string CompletedText { get=>completedText; private set=>completedText=value; }

        private TextMeshProUGUI _dialogName;

        private TextMeshProUGUI _dialogText;

        public TextMeshProUGUI DialogText { get=>_dialogText; private set=>_dialogText=value; }
        // Start is called before the first frame update
        void Start()
        {
            WaitingState = new WaitingForCompletionState();
            GiveState = new GiveTaskState();
            CompletedState = new CompletedTaskState();
            currentState = GiveState;
            _dialogName = uiDialog.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _dialogName.SetText("Мудрый дуб");
            _dialogText = uiDialog.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            currentState.UpdateState(this);
            if (Input.GetButtonDown("Activate") && isPlayerNear)
            {
                // Debug.Log("bcd");
                uiHint.SetActive(false);
                currentState.EnterState(this);
            }
        }

        public void SwitchState(NpcBaseState state)
        {
            currentState = state;
            //currentState.EnterState(this);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player"))
            {
                return;
            }
            uiHint.SetActive(true);
            isPlayerNear = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isPlayerNear = false;
                uiHint.SetActive(false);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            //Debug.Log("abc");
            
        }
    }
}
