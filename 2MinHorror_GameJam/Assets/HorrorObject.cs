using UnityEngine;

public class HorrorObject : MonoBehaviour,ItriggerEvent
{
    /// <summary>
    /// 允許子類別覆寫觸發事件 (實力化 後 加上 virtual )
    /// </summary>
    public virtual void TriggerEvent()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "玩家") TriggerEvent();
    }

}
