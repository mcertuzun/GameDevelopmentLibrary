using System;

namespace Assets.Library.Model
{
    public interface ILifeHandler : IParameterHolder<float>
    {
        event Action OnDamageTaken;
        event Action OnDeath;

        void getDamage(float amount);
        void die();
        void addLife(float amount);

    }
}