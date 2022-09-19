using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Servises
{
    internal class FileIOServises
    {
        private readonly string PATH;
        public FileIOServises(string path)
        {
            PATH = path;
        }
        public BindingList<TodoModel> LoadData()
        {
            var fileExist =File.Exists(PATH);
            if (!fileExist )
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();    
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText); 
            }

            
        }

        public void SaveData(object  _todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert .SerializeObject(_todoDataList);
                writer.Write(output);
            }

        }
    }
}
