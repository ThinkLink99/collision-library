using Microsoft.Xna.Framework;
using System;

namespace CarKrash.Collision.UI
{
    public interface IClick
    {
        event Action onClick;

        void Click();
    }
}
