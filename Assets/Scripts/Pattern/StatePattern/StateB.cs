using Pattern.StatePattern;
using UnityEngine;

namespace StatePattern
{
    public class StateB : IState
    {
        public void Handle(Context context, int arg)
        {
            Debug.Log("StateB: " + arg);
            if (arg <= 10)
            {
                context.SetState(new StateA());
            }
        }
    }
}