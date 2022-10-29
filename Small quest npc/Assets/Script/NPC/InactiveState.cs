using UnityEngine;

namespace Script.NPC
{
    public class InactiveState : NpcBaseState
    {
        public override void UpdateState(NpcContext context)
        {
            return;
        }

        public override void OnTriggerEnterState(NpcContext context, Collider2D other)
        {
            return;
        }

        public override void EnterState(NpcContext context)
        {
            return;
        }
    }
}