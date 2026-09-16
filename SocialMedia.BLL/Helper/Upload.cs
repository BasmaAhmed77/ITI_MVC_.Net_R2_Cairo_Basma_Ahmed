using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BLL.Helper
{
    public static class Upload
    {
        public static string UploadFile(string folderName, IFormFile file)
        {
			try
			{
				string folderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + folderName;
				string fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
				string finalPath = Path.Combine(folderPath , fileName);
				using (var stream = new FileStream(finalPath,FileMode.Create))
				{
					//File.CopyTo(stream);
					file.CopyTo(stream);
				}
				return fileName;
            }
			catch (Exception ex)
			{
				return ex.Message;
            }
        }

		public static string RemoveFile(string folderName, string fileName)
		{
			try
			{
				var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName, fileName);
				if (File.Exists(directory))
				{
					File.Delete(directory);
					return "File Deleted";
                }
				return "File Not Deleted";
			}

			catch (Exception ex)
			{
				return ex.Message;
			}
		}
    }
}
