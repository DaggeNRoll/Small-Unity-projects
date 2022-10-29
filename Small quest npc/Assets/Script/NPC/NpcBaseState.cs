using UnityEngine;

namespace Script.NPC
{
    public abstract class NpcBaseState
    {
        public abstract void UpdateState(NpcContext context);
        public abstract void OnTriggerEnterState(NpcContext context, Collider2D other);
        public abstract void EnterState(NpcContext context);

    }
}