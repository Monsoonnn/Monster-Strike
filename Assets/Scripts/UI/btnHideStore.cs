using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnHideStore : BaseBtn
{
    protected override void OnClick() {

        Debug.Log("Đã toggle");
        StoreUI.Instance.Toggle();


    }
}
