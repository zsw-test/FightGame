using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Property
{
    AddBigSkill,
    AddEnerge,
    AddBlood,
    SpeedUp,
    SpeedDown,
    Dazzle,


}
public interface BaseProperty
{
    void Attach(GameObject player);
}
