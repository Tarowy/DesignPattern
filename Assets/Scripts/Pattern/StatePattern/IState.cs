using Pattern.StatePattern;

namespace StatePattern
{
    public interface IState
    {
        void Handle(Context context, int arg);
    }
}