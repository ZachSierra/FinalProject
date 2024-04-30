using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAIPatrolState : CreatureAIState
{
    public CreatureAIPatrolState(CreatureAI creatureAI) : base(creatureAI){}

    public override void BeginState()
    {
        MoveRandom();
        
    }
    Vector3 moveVec;
    public override void UpdateState()
    {
        if(timer > 1.5f){
            timer = 0;

            MoveRandom();
        }

        //creatureAI.myCreature.MoveCreature(moveVec);

        if(creatureAI.GetTarget() != null){
            creatureAI.ChangeState(creatureAI.hugState);
        }
    }

    public void MoveRandom(){
        RaycastHit2D hit;
        Vector3 moveVec;
        

        do{
            moveVec = (new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0));
            hit = Physics2D.Linecast(creatureAI.myCreature.transform.position, moveVec,10);
        }while(hit.collider != null);
    }

}