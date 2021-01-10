using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseBooster: MonoBehaviour //This defines the Booster template class per say
{
    public abstract void ApplyBooster(Padel currentPadel, Ball triggeredBall = null);
    


}
