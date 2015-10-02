using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Com.Ktbl.RiskManagement.Web.Models
{
    public class CommonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<CommonModel> GenDummy(int length)
        {
            var list = new List<CommonModel>();
            for (int i = 0; i < length; i++)
            {
                list.Add(new CommonModel
                {
                    Id = i,
                    Name = RandomUtil.GetRandomString(),
                    IsActive = true
                });
            }
            return list;
        }
    }

    static class RandomUtil
    {
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}