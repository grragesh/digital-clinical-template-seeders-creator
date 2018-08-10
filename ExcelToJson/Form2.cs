using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ExcelToJson
{
   
    public partial class Form2 : Form
    {
        int id = 208;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create JavaScriptSerializer instance.
           JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string jsonData = richTextBox1.Text;
            StringBuilder sb = new StringBuilder(); 
            // Deserialize JSON data into list of Vehicles.
            List<List<RootObject>> finalResult = jsSerializer.Deserialize<List<List<RootObject>>>(jsonData);
            foreach (List<RootObject> res in finalResult)
            {
                List<TemplateSections> obj = FetchJson(res);
                sb.Append(JsonConvert.SerializeObject(obj, Formatting.Indented));
            }
            richTextBox1.Text = sb.ToString();
        }


        private bool Loop(List<RootObject> JSON,int Order, out RootObject objRootObject)
        {
            objRootObject = null;
            bool LoopAlive = false;
            for (var i=0;i< JSON.Count;i++)
            {
                if(Order== Convert.ToInt32(JSON[i].order))
                {
                    LoopAlive = true;
                    objRootObject = JSON[i];
                }
            }
            return LoopAlive;
        }


        public dynamic FetchJson(List<RootObject> JSON)
        {
            TemplateSections newJson;
            List<TemplateSections> result = new List<TemplateSections>();

            int Order = 1;
            RootObject obj;
            while (Loop(JSON, Order, out obj))
            {
                Order= Order++;

                newJson = new TemplateSections();
                newJson.id = id++;
                newJson.uuid = obj.sectionId;
                newJson.TemplateId = 2;
                newJson.jsonSectionStruture = new JsonSectionStructure
                {
                    sectionId = obj.sectionId,
                    order = obj.order,
                    number = obj.number,
                    title = obj.title ?? "",
                    level = obj.level,
                    type = obj.type,
                    content = obj.content,
                    instructionText = obj.instructionText,
                    exampleText = obj.exampleText,
                    options = obj.options

                };
                newJson.createdAt = "";
                newJson.updatedAt = "";
                result.Add(newJson);

                if (obj.sections.Count > 0)
                {
                    result.AddRange(FetchJson(obj.sections));
                }
            }

            //foreach(RootObject obj in JSON)
            //{
               
            //        newJson = new TemplateSections();
            //        newJson.id = id++;
            //        newJson.uuid = obj.sectionId;
            //        newJson.TemplateId = 2;
            //        newJson.jsonSectionStruture = new JsonSectionStructure
            //        {
            //            sectionId = obj.sectionId,
            //            order = obj.order,
            //            number = obj.number,
            //            title = obj.title ?? "",
            //            level=obj.level,
            //            type = obj.type,
            //            content = obj.content,
            //            instructionText = obj.instructionText,
            //            exampleText = obj.exampleText,
            //            options = obj.options

            //        };
            //        newJson.createdAt= "";
            //        newJson.updatedAt = "";
            //        result.Add(newJson);
                
            //    if(obj.sections.Count>0)
            //    {                    
            //       result.AddRange(FetchJson(obj.sections));
            //    }

            //}
            return result;
        }
    }
    public class TemplateSections
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public int TemplateId { get; set; }
        public JsonSectionStructure jsonSectionStruture { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }

    public class JsonSectionStructure
    {
        public string sectionId { get; set; }
        public string order { get; set; }
        public string number { get; set; }
        public string title { get; set; }
        public string level { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public string instructionText { get; set; }
        public string exampleText { get; set; }
        public Object options { get; set; }
    }

    public class RootObject
    {
        public string sectionId { get; set; }
        public string order { get; set; }
        public string number { get; set; }
        public string title { get; set; }
        public string level { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public string instructionText { get; set; }
        public string exampleText { get; set; }
        public bool Visited { get; set; }
        public Object options { get; set; }
        public List<RootObject> sections { get; set; }
    }
}
