namespace WebApplication1.BL.Helper
{
    public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile FileUrl, string FolderName)
        {
            string FilePath = Directory.GetCurrentDirectory()+ "/wwwroot/Files/" + FolderName;
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);
            string FinalPath = Path.Combine(FilePath, FileName);
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }
            return FileName;
        }
        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() +"/wwwroot/Files/"+FolderName+"/"+RemovedFileName ))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + "/" + RemovedFileName);
            }
        }
    }
}
