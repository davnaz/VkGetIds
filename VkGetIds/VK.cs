using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkGetIds.Properties;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkGetIds
{
    public class VK
    {
        public VkApi vk;
        public VK()
        {
            vk = new VkApi();
            try
            {
                vk.Authorize(new ApiAuthParams
                {
                    ApplicationId = Convert.ToUInt64(Resources.AppId),
                    Login = Resources.Login,
                    Password = Resources.Password,
                    Settings = VkNet.Enums.Filters.Settings.All
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<string> DoSomething()
        {
            VkApi vk = new VkApi();
            List<string> idss = new List<string>();
            try
            {
                vk.Authorize(new ApiAuthParams
                {
                    ApplicationId = Convert.ToUInt64(Resources.AppId),
                    Login = Resources.Login,
                    Password = Resources.Password,
                    Settings = VkNet.Enums.Filters.Settings.All
                });

                List<string> links = @"https://vk.com/zlaiapatcifistka".Split('\n').ToList();
                for (int i = 0; i < links.Count; i++)
                {
                    links[i] = links[i].Split('/')[links[i].Split('/').Length - 1].Replace("\r", "");
                }

                //var ids = vk.Users.Get(links);
                //foreach(var id in ids)
                //{
                //    idss.Add($"{id.FirstName} https://vk.com/id{id.Id}");
                //}

                return idss;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string getVkID(string link)
        {
            List<string> item = new List<string>();
            item.Add(link.Split('/')[link.Split('/').Length - 1].Replace("\r", ""));
            var id = this.vk.Users.Get(item);
            if (id.Count > 0)
            {
                return $"https://vk.com/id{id[0].Id}";
            }
            else
            {
                return "Неверный адрес";
            }
        }
    }
        

    
}
