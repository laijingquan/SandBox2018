using HedgehogTeam.EasyTouch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour {

    void OnEnable()
    {
        //启动On_SimpleTap监听，也就是手指单击屏幕，就会触发On_MySimpleTap的方法执行
        EasyTouch.On_SimpleTap += On_MySimpleTap;
    }
    // Unsubscribe
    void OnDisable()
    {
        EasyTouch.On_SimpleTap -= On_MySimpleTap;//去除监听
    }
    // Unsubscribe
    void OnDestroy()
    {
        EasyTouch.On_SimpleTap -= On_MySimpleTap;//去除监听
    }
    // Touch start event
    public void On_MySimpleTap(Gesture gesture)
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 0.5f, 1);//单击的时候将Cube的颜色改为白色
    }
}
