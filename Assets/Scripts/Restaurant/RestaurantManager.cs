using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantManager : Singleton<RestaurantManager>
{
    public Queue<NPCBehaviour> npcWaitQueue;

    public NPCBehaviour currentWaitNpc;

    public void AddWaitQueue(NPCBehaviour _npc)
    {
        npcWaitQueue.Enqueue(_npc);
    }

    public NPCBehaviour GetWaitQueue()
    {
        currentWaitNpc = npcWaitQueue.Dequeue();
        return currentWaitNpc;
    }

    public RecipeData GetWantRecipe() {
        return NPCDataUtility.GetRecipeToRandom(ref currentWaitNpc.npcData);
    }




}
