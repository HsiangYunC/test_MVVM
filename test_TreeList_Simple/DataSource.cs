using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Test_TreeList_Simple
{
    /// <summary>
    /// DataSource
    /// </summary>
    public static class DataSource
    {
        /// <summary>
        /// GetFileList
        /// </summary>
        /// <param name="dir">dir</param>
        /// <returns>BindingList<FileInfo></returns>
        public static BindingList<FileInfo> GetFileList(string dir)
        {
            var files = Directory.GetFiles(dir).Select(file => new FileInfo(file)).ToList();
            return new BindingList<FileInfo>(files);
        }
    }
}
