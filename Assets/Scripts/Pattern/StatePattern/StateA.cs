using Pattern.StatePattern;
using UnityEngine;

namespace StatePattern
{
    public class StateA : IState
    {
        public void Handle(Context context, int arg)
        {
            Debug.Log("StateA: " + arg);

            if (arg > 10)
            {
                //切换到状态B
                context.SetState(new StateB());
            }
        }
    }
}