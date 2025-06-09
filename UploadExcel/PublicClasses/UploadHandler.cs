namespace UploadExcel.PublicClasses
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            //extension
            List<string> allowedExtensions = new List<string> { ".xls", ".xlsx" };
            string extension = Path.GetExtension(file.FileName);

            if (allowedExtensions.Contains(extension))
            {
                return $"File extension is valid. ({string.Join(',', allowedExtensions)})";
            }

            //file size
            long size = file.Length;
            if (size > (50 * 1024 * 1024)) // 50 MB
            {
                return "File size exceeds the limit of 50 MB.";
            }

            //name changing
            string newFileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(Path.Combine(path, newFileName), FileMode.Create);
            file.CopyTo(stream);

            return newFileName;
        }
    }
}
