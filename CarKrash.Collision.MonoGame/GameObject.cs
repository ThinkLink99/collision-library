using CarKrash.Collision.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace CarKrash.Collision
{
    public class GameObject
    {
        private List<Component> Components { get; }

        public GameObject()
        {
            this.Components = new List<Component>();
        }

        /// <summary>
        /// Adds a component to be managed by the engine on the back-end
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent (Component component)
        {
            component.SetParent(this);
            Components.Add(component);
        }
        /// <summary>
        /// Removes a component from the GameObject
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(Component component)
        {
            component.SetParent(null);
            Components.Remove(component);
        }
        public T FindComponent<T> ()
        {
            return Components.Where(c => c is T).Cast<T>().FirstOrDefault();
        }
        public void FindComponent<T>(out T component)
        {
            component = Components.Where(c => c is T).Cast<T>().FirstOrDefault();
        }

        public virtual void Draw(CSpriteBatch spriteBatch)
        {
            var d = Components.Where(c => c is Graphics.IDrawable).Cast<Graphics.IDrawable>().ToList();
            foreach (Graphics.IDrawable drawable in d)
            {
                drawable.Draw(spriteBatch);
            }
        }
    }
}
