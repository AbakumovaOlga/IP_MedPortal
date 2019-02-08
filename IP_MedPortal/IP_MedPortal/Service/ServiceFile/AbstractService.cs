using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service
{
    public abstract class AbstractService: IMain
    {
        public XmlSerializer xsSubmit { get; set; }
        public string currentPath { get; set; }
        public String Name { get; set; }

        public void DelElement(int id)
        {
            File.Delete(currentPath + "/" + Name + id + ".txt");
        }

        public void UpdateElement(BaseModel model)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, model);
            File.WriteAllText(currentPath + "/" + Name + model.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();
        }

        public void AddElement(BaseModel model)
        {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"" + Name + @"\d+");
                int currentId = Convert.ToInt32(m.Value.Replace(Name, ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            model.Id = id;
            string newFilePath = currentPath + "/" + Name + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, model);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public BaseModel GetElement(int id)
        {
            BaseModel model;
            using (StreamReader stream = new StreamReader(currentPath + "/" + Name + id + ".txt", true))
            {
                model = (BaseModel)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return model;
        }

        public List<BaseModel> GetList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<BaseModel> abstractList = new List<BaseModel>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                BaseModel rashod = (BaseModel)xsSubmit.Deserialize(stream);
                abstractList.Add(rashod);
                stream.Close();
            }
            return abstractList;
        }
    }
}