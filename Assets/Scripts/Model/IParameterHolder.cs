using System;

namespace Assets.Library.Model
{
    public interface IParameterHolder<T>
    {
        event Action<T> onValueUpdate;
        T getCurrent();
        T getMax();
        T getPercent();
        bool tagCheck(string tag);

    }
}