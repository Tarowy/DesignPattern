using StatePattern;

namespace Pattern.StatePattern
{
    public class Context
    {
        private IState _state;

        public Context() => _state = new StateA();

        public Context(IState state)
        {
            SetState(state);
        }

        public void SetState(IState state) => _state = state;


        public void Handle(int arg)
        {
            _state.Handle(this, arg);
        }
    }
}