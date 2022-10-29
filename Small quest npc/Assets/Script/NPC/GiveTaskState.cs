using TMPro;
using UnityEngine;

namespace Script.NPC
{
    public class GiveTaskState : NpcBaseState
    {
        public override void UpdateState(NpcContext context)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                ExitState(context);
            }
        }

        public override void OnTriggerEnterState(NpcContext context, Collider2D other)
        {
            throw new System.NotImplementedException();
        }

        public override void EnterState(NpcContext context)
        {
            //var texts = context.UiDialog.GetComponentsInChildren<TextMeshProUGUI>();
            
            
            context.DialogText.SetText(context.TaskText);
            
            context.UiDialog.SetActive(true);
            Time.timeScale = 0;
        }

        public void ExitState(NpcContext context)
        {
            GameManager.Instance.HasTask = true;
            context.UiDialog.SetActive(false);
            Time.timeScale = 1;
            context.SwitchState(context.WaitingState);
        }
    }
}