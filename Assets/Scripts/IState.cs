using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void DoAction();
}

//状态上下文环境
public class StateContext
{
    private IState mState;

    public IState MState { get => mState; set => mState = value; }

    public void DoAction()
    {
        mState.DoAction();
    }
    //public void SetState(IState state)
    //{
    //    this.State = state;
    //}
    //public IState GetState()
    //{
    //    return this.State;
    //}
    
}
public class StateIdle : IState
{
    private StateContext mContext;
    public StateIdle(StateContext context)
    {
        mContext = context;
    }
    public void DoAction()
    {
        Debug.Log("Idle");
        mContext.MState = new StateAtk1(mContext);
    }
}
public class StateAtk1 : IState
{
    private StateContext mContext;
    public StateAtk1(StateContext context)
    {
        mContext = context;
    }
    public void DoAction()
    {
        Debug.Log("Akt1");
    }
}
