using Microsoft.Xna.Framework;
using System;

namespace Collision.UI
{
    public interface IClick
    {
        event Action onClick;

        void Click();
    }
}
