namespace Collision
{
    public class Grid<TGridObject>
    {
        public class GridChangedEventArgs : System.EventArgs
        {
            public TGridObject gridObject;
            public GridChangedEventArgs(TGridObject gridObject)
            {
                this.gridObject = gridObject;
            }
        }

        public event System.EventHandler<GridChangedEventArgs> OnGridChanged;

        private int width;
        private int height;
        private float cellSize;
        private TGridObject[,] gridArray;

        public Grid(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridArray = new TGridObject[width, height];
        }

        private bool XisValid (int x)
        {
            return x >= 0 && x <= width;
        }
        private bool YisValid(int y)
        {
            return y >= 0 && y <= height;
        }

        public TGridObject GetGridObject(int x, int y)
        {
            if (XisValid(x) && YisValid(y))
            {
                return gridArray[x, y];
            }
            return default(TGridObject);
        }

        public void AddObject (TGridObject gridObject, int x, int y)
        {
            gridArray[x, y] = gridObject;
            OnGridChanged?.Invoke(this, new GridChangedEventArgs(gridObject));
        }
        public void RemoveObject (int x, int y)
        {
            TGridObject gridObject = gridArray[x, y];
            gridArray[x, y] = default;
            OnGridChanged?.Invoke(this, new GridChangedEventArgs(gridObject));
        }
    }
}
