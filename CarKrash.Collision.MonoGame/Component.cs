namespace CarKrash.Collision
{
    public abstract class Component : IReadableComponent, IWritableComponent
    {
        private GameObject parent;

        public GameObject Parent => parent;
        GameObject IWritableComponent.Parent { set => parent = value; }


        internal void SetParent(GameObject parent) { this.parent = parent; }
    }

    public interface IReadableComponent
    {
        GameObject Parent { get; }
    }
    public interface IWritableComponent
    {
        GameObject Parent { set; }
    }
}
