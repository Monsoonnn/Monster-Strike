using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnToggleLeaderBoard : BaseBtn
{
    protected override void OnClick() {

        LeaderBoardUI.Instance.Toggle();
      
        


    }
}
