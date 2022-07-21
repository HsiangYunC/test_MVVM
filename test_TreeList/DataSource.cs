using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Test_TreeList
{
    /// <summary>
    /// DataSource
    /// </summary>
    public static class DataSource
    {
        /// <summary>
        /// ModelList
        /// </summary>
        public static readonly Dictionary<int, BindingList<Model>> ModelList =
            new Dictionary<int, BindingList<Model>>();

        /// <summary>
        /// ModelList2
        /// </summary>
        public static readonly Dictionary<Guid, BindingList<Model>> ModelList2 =
            new Dictionary<Guid, BindingList<Model>>();

        private static Random _random = new Random();

        static DataSource()
        {
            for (int i = 0; i < 3; i++)
            {
                ModelList[i] = new BindingList<Model>();

                for (int j = 0; j < _random.Next(1, 10); j++)
                {
                    AddItem(i);
                }
            }
        }

        /// <summary>
        /// AddItem
        /// </summary>
        /// <param name="index">page index</param>
        public static void AddItem(int index)
        {
            if (ModelList.ContainsKey(index))
            {
                var newItem = (Fruit)_random.Next(0, 10);
                var findModel = ModelList[index].Where(x => x.Item == newItem.ToString()).FirstOrDefault();

                int addCount = _random.Next(1, 5);
                if (findModel == null)
                {
                    findModel = new Model(newItem, addCount);

                    AddSubitem(findModel.Id, newItem, addCount);

                    ModelList[index].Add(findModel);
                }
                else
                {
                    AddSubitem(findModel.Id, newItem, addCount);

                    findModel.Count += addCount;
                }
            }
        }

        /// <summary>
        /// RemoveItem
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="model">model</param>
        public static void RemoveItem(int index, Model model)
        {
            if (ModelList.ContainsKey(index))
            {
                ModelList[index].Remove(model);
            }
        }
        /// <summary>
        /// RemoveItem
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="id">id</param>
        public static void RemoveItem(int index, Guid id)
        {
            if (ModelList.ContainsKey(index))
            {
                ModelList[index].Remove(ModelList[index].Where(x => x.Id == id).FirstOrDefault());
            }
        }

        private static void AddSubitem(Guid id, Fruit item, int count)
        {
            if (!ModelList2.ContainsKey(id))
            {
                ModelList2[id] = new BindingList<Model>();
            }

            ModelList2[id].Add(new Model(item, count));
        }
    }
}
