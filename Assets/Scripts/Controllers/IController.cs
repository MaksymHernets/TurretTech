using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    void Init(IModel model);
    void Deactive();
}
