using Microsoft.AspNetCore.Authorization;
using SEOManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEOManagement.Services
{
    [Authorize]
    public class SEOService
    {
        public SEOService()
        {

        }

        public SEOMetaData Get(string path)
        {
            SEOMetaData data = new SEOMetaData();

            path = CleanPath(path);

            using (var context = new ApplicationContext())
            {
                data = context.SEOMetaData.Single(x => x.Path == path);
            }

            //missing page, so get and use default
            if (data == null)
            {
                using (var context = new ApplicationContext())
                {
                    //default id is always 1
                    data = context.SEOMetaData.Single(x => x.Id == 1);
                }
            }

            return data;
        }

        public SEOMetaData Get(int id)
        {
            SEOMetaData data = new SEOMetaData();

            using (var context = new ApplicationContext())
            {
                data = context.SEOMetaData.Single(x => x.Id == id);
            }

            return data;
        }

        public async Task<int> AddAsync(SEOMetaData data)
        {
            int success = 0;

            try
            {
                using (var context = new ApplicationContext())
                {
                    data.Path = CleanPath(data.Path);
                    context.SEOMetaData.Add(data);
                    await context.SaveChangesAsync();

                    success = 1;
                }
            }
            catch
            {
            }

            return success;
        }

        public async Task<int> UpdateAsync(SEOMetaData data)
        {
            int success = 0;


            try
            {
                using (var context = new ApplicationContext())
                {
                    data.Path = CleanPath(data.Path);

                    context.SEOMetaData.Update(data);
                    await context.SaveChangesAsync();

                    success = 1;
                }
            }
            catch
            {
            }


            return success;
        }

        public int Delete(int id)
        {
            int success = 0;
            //can never delete default
            if (id != 1)
            {
                try
                {
                    using (var context = new ApplicationContext())
                    {
                        var data = context.SEOMetaData
                        .Where(a => a.Id == id)
                        .FirstOrDefault();

                        context.SEOMetaData.Remove(data);
                        context.SaveChanges();
                    }

                    success = 1;
                }
                catch
                {
                }
            }

            return success;
        }

        public List<SEOMetaData> GetAll()
        {
            List<SEOMetaData> data = new List<SEOMetaData>();

            using (var context = new ApplicationContext())
            {
                //getting all but default so that it needs to be edited seperately
                data = context.SEOMetaData.Where(b => b.Id > 1).OrderByDescending(b => b.Id).ToList();
            }

            return data;
        }

        public string CleanPath(string path)
        {
            path = path.Replace("http://www.ourcompany.com", "");
            path = path.Replace("https://www.ourcompany.com", "");
            path = path.Replace("https://sloturl.azurewebsites.net", "");
            path = path.Replace("http://sloturl.azurewebsites.net", "");
            path = path.Replace("http://localhost:52285", "");
            path = path.Replace("https://localhost:44385", "");

            return path;
        }
    }
}
