using Digital_Pet_Passport.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
namespace Digital_Pet_Passport.Model
{
    public class Image : IContext
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int PetsId { get; set; }

        public Pet Pet { get; set; }

        [NotMapped]
        public string NameGallerey { get; set; }

        public const string ImageGallereyPets = "ImageGallereyPets";

        public Image()
        {
            NameGallerey = $"{ImageGallereyPets} № {Id}";
        }

        /// <summary>
        /// Сохранение изображения в приложении
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="name">Имя нового файла</param>
        /// <returns>Возвращает путь скопированного файла</returns>
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
                if (File.Exists(fullpath))
                {
                    RemoveImage(fullpath);
                 
                }
                fileInfo.CopyTo(fullpath);
                return fullpath;
            }

            return "";
        }

        /// <summary>
        /// Копирует изображение во внутренние хранилище по указанному. Под свойства NameGallerey.
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Возвращает путь скопированного файла</returns>
        public string SaveImg(string path)
        {
            return SaveImg(path, NameGallerey);
        }

        /// <summary>
        /// Удаление изображения по переданному пути
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void RemoveImage(string path)
        {
            if (path != "DefoultPetImage.png")
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
}
