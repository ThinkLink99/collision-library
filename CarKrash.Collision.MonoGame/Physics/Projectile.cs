using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarKrash.Collision.Physics2D
{
    public class Projectile : IDisposable
    {
        public event Action OnHit;

        BoxCollider2D collider;
        Vector3 direction = Vector3.Zero;
        float speed = 4f;
        private bool disposedValue;

        public Projectile (Vector3 position, Vector3 size, float speed = 4f)
        {
            collider = new BoxCollider2D(true, new Transform(position, size));
            collider.onCollide += Collider_onCollide;
        }
        public Projectile(Vector3 position, Vector3 size, Func<Action> func, float speed = 4f)
        {
            collider = new BoxCollider2D(true, new Transform(position, size));
            collider.onCollide += func.Invoke();
        }

        private void Collider_onCollide()
        {
            End(dispose: true);
        }

        public void Begin (Vector3 direction)
        {
            this.direction = direction;
        }
        public void End (bool dispose)
        {
            OnHit?.Invoke();

            direction = Vector3.Zero;
            if (dispose) { Dispose(); }
        }

        // TODO: run collider code in background from game or scene class? maybe? perhaps? 
        public void Update (GameTime gameTime, List<BoxCollider2D> collider2Ds)
        {
            if (direction == Vector3.Zero) return;

            collider.Transform.Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            collider.Update(gameTime, collider2Ds);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Projectile()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public Transform Transform => collider.Transform;
    }
}
