using UnityEngine;

namespace Script.NPC
{
    public class CompletedTaskState : NpcBaseState
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
            
        }

        public override void EnterState(NpcContext context)
        {
            context.DialogText.SetText(context.CompletedText);
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