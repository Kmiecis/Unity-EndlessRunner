using System.Collections.Generic;

namespace Game
{
    public class Pooler : APoolerProvider
    {
        public PoolingObject prefab;

        private Queue<PoolingObject> m_Pool = new Queue<PoolingObject>();

        private PoolingObject CreateNewObject()
        {
            return Instantiate(prefab, transform.position, transform.rotation, transform);
        }

        private PoolingObject GetBorrowItem()
        {
            if (m_Pool.Count > 0)
                return m_Pool.Dequeue();
            var item = CreateNewObject();
            item.pooler = this;
            return item;
        }

        public PoolingObject Borrow()
        {
            var item = GetBorrowItem();
            item.OnBorrow();
            return item;
        }

        public void Return(PoolingObject item)
        {
            item.OnReturn();
            m_Pool.Enqueue(item);
        }

        public override Pooler GetPooler()
        {
            return this;
        }

        private void Start()
        {
            Return(Borrow());
        }
    }
}