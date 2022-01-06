using Digital_Pet_Passport.Intefaces;
using System.IO;
namespace Digital_Pet_Passport.Model
{
    public class Image : IContext
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int PetsId { get; set; }

        public Pet Pet { get; set; }

        /// <summary>
        /// Сохранение изображения в приложении
        /// </summary>
        public string SaveImg(string path, string name)
        {
            string inst = new Logic.BaseWorkFiles().InRootPath;
            string fullpath = string.Empty;
            FileInfo fileInfo = new FileInfo(path);
            string ex = fileInfo.Extension;
            if (ex.ToUpper() == ".jpg".ToUpper() ||
                ex.ToUpper() == ".png".ToUpper() ||
                ex.ToUpper() == ".jpeg".ToUpper())
            {
                fullpath = System.IO.Path.Combine(inst, name.Trim() + ex);
                fileInfo.CopyTo(fullpath);
                return fullpath;
            }

            return "";
        }

        public void RemoveImage(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

#if DEBUG
            if (File.Exists(path))
            {

            }
#endif


        }

    }
}
