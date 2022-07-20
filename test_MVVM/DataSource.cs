using System;
using System.ComponentModel;
using System.Linq;

namespace test_MVVM
{
    static class DataSource
    {
        public static readonly BindingList<Model> ModelList = new BindingList<Model>();

        static DataSource()
        {
            ModelList.Add(new Model("Book", 100));
            ModelList.Add(new Model("Pen", 20));
            ModelList.Add(new Model("Eraser", 5));
        }

        public static void AddItem(Model model)
        {
            ModelList.Add(model);
        }

        public static void RemoveItem(Model model)
        {
            ModelList.Remove(model);
        }
        public static void RemoveItem(Guid id)
        {
            ModelList.Remove(ModelList.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
