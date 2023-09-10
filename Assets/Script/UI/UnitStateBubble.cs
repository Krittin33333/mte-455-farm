using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStateBubble : MonoBehaviour
{
    public Image stateBubbleImg;

    public Sprite miningState;
    public Sprite attackState;
    public Sprite PlowState;
    public Sprite SowState;
    public Sprite WaterState;
    public Sprite HarvestState;
    public Sprite DeliverState;

    public void OnStateChange(UnitState state)
    {
        stateBubbleImg.enabled = true;
        CheckState(state);
    }
    
    private void CheckState(UnitState state)
    {
        switch (state)
        {
            case UnitState.Mining:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = miningState;
                break;
            case UnitState.AttackUnit:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = attackState;
                break;
            case UnitState.AttackBuilding:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = attackState;
                break;
            case UnitState.Plow:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = PlowState;
                break;
            case UnitState.Sow:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = SowState;
                break;
            case UnitState.Water:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = WaterState;
                break;
            case UnitState.Harvest:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = HarvestState;
                break;
            case UnitState.MoveToDeliver:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = DeliverState;
                break;
            
            // else
            default:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.enabled = false;
                break;
        }
    }
}