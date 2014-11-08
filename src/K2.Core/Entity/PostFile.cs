using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.IO;
using System.Web;
using _2K.Core.Entity.Base;

namespace _2K.Core.Entity
{
    public class PostFile: BaseFile
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        /// <summary>
        /// Get or sets the file byte data.
        /// </summary>
        [NotMapped]
        public byte[] Data
        {
            get { return File.ReadAllBytes(this.FullPath); }
            set { File.WriteAllBytes(this.FullPath,value);}
        }
        /// <summary>
        /// Get the relative path for app.
        /// </summary>
        public string RelativePath
        {
            get { return ConfigurationManager.AppSettings["2KFilePath"] + string.Format("{0}.{1}",this.ItemId, Extension); }
        }

        /// <summary>
        /// Get the full path for app.
        /// </summary>
        public string FullPath
        {
            get
            {
                var appPath = HttpContext.Current.Request.PhysicalApplicationPath;
                return appPath != null? Path.Combine(appPath, RelativePath):null;
            }
        }

        internal void DeleteData()
        {
            File.Delete(FullPath);
        }
    }
}
