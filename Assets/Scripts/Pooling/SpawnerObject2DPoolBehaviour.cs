using Common.Pooling;

namespace Game
{
    public class SpawnerObject2DPoolBehaviour : RepoolablePoolBehaviour<SpawnerObject2D>
    {
        public override IRepoolable<SpawnerObject2D> Borrow()
        {
            var item = base.Borrow();
            item.Value.transform.SetParent(this.transform);
            return item;
        }
    }
}
