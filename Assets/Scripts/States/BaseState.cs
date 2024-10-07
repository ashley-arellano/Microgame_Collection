using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract state of fsm
public abstract class BaseState 
{
   public abstract void EnterState(GameStateMachine gameStateMachine);
   public abstract void UpdateState(GameStateMachine gameStateMachine);
   public abstract void DestroyState();
}
