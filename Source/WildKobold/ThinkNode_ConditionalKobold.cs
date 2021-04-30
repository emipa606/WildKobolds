using System.Linq;
using RimWorld;
using Verse;
using Verse.AI;

namespace WildKobold
{
    internal class ThinkNode_ConditionalKobold : ThinkNode_Conditional
    {
        protected override bool Satisfied(Pawn pawn)
        {
            // If we're dealing with a kobold.
            if (pawn.def != null && pawn.def.defName == "Kobold" && !pawn.GetRegion().touchesMapEdge)
                // Return true if the kobold is untrained or outside of the home area.
            {
                return pawn.training == null ||
                       !pawn.training.HasLearned(DefDatabase<TrainableDef>.GetNamed("Obedience")) ||
                       !pawn.Map.areaManager.Home.ActiveCells.Contains(pawn.Position);
            }

            // The pawn isn't an eligible kobold - fail.
            return false;
        }
    }
}