using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMenuState 
{
   public abstract void EnterState(MenuStateMachine menuStateMachine);
   public abstract void UpdateState(MenuStateMachine menuStateMachine);
   public abstract void DestroyState(MenuStateMachine menuStateMachine);
   public abstract void SetUpState(MenuStateMachine menuStateMachine);
   public abstract void SetUpWrapper();
}
