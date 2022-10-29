using UnityEngine;

namespace Script.NPC
{
    public class WaitingForCompletionState : NpcBaseState
    {
        public override void UpdateState(NpcContext context)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                ExitState(context);
            }

            if (GameManager.Instance.HasItem)
            {
                context.SwitchState(context.CompletedState);
            }
        }

        public override void OnTriggerEnterState(NpcContext context, Collider2D other)
        {
            
        }

        public override void EnterState(NpcContext context)
        {
            
            context.DialogText.SetText(context.WaitingText);
            context.UiDialog.SetActive(true);
            Time.timeScale = 0;
        }

        public void ExitState(NpcContext context)
        {
            context.UiDialog.SetActive(false);
            Time.timeScale = 1;
        }
    }
}