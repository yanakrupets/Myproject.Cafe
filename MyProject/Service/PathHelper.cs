using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public class PathHelper : IPathHelper
    {
        private IWebHostEnvironment _hostEnvironment;

        public PathHelper(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public string GetPathToCarouselFolder()
        {
            var webPath = _hostEnvironment.WebRootPath;
            var path = Path.Combine(webPath, "images", "carousel");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public string GetPathToAvatarFolder()
        {
            var webPath = _hostEnvironment.WebRootPath;
            var path = Path.Combine(webPath, "images", "avatars");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public string GetPathToAvatarByUser(long id)
        {
            var avatarFolderPath = GetPathToAvatarFolder();
            return Path.Combine(avatarFolderPath, $"{id}.jpg");
        }

        public string GetAvatarUrlByUser(long id) 
        {
            return $"/images/avatars/{id}.jpg";
        }
    }
}
