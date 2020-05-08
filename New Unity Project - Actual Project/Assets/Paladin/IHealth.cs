using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
    bool CheckIsAlive();
    void Damage(float amount);
    void DamagedBySpell(int spellId);

}
