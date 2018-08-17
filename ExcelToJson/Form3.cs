using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
namespace ExcelToJson
{
    public partial class Form3 : Form
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;
        int TotalRowCount = -1;
        int CurrentRowNumber = 1;
        int TotalColumnCount = -1;
        int CurrentOrder = -1;
        dynamic JSONIndividualSeeders = null;
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sectionType.Value != 0 && SectionNames.Value != 0 && SectionNumber.Value != 0 && instructionText.Value != 0 && boliertext.Value != 0 && exampleText.Value != 0 && SectionNumber.Value != 0)
            {

                string fileName = openFileDialog1.FileName;
                string fileextns = System.IO.Path.GetExtension(fileName);
                ReadExcel(fileName, fileextns);
            }
        }
        public void ReadExcel(string fileName, string fileExt)
        {

            xlApp = new Excel.Application();
            JSONIndividualSeeders = new JArray();
            xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = xlWorkBook.ActiveSheet;
            range = xlWorkSheet.UsedRange;
            TotalRowCount = range.Rows.Count;
            TotalColumnCount = range.Columns.Count;
            CurrentRowNumber = 1;
            int templateId = Convert.ToInt32(TemplateId.Value);
            int templateSec = Convert.ToInt32(TemplateSectionId.Value);
            dynamic JSONDocumentMetaStructure = new JArray();
            dynamic JsonArray = null;
            int order = 1;
            int level = 0;
            CurrentOrder = 1;
            while (CurrentRowNumber<=TotalRowCount && CurrentRowNumber+1 <= TotalRowCount)
            {
                string number = Convert.ToString((range.Cells[CurrentRowNumber+1, SectionNumber.Value] as Excel.Range).Value2);
                if( !(number.Contains(".") || number.Contains("none")) )
                    {
                    dynamic temp = FetchSections(CurrentOrder++, level);
                    if(temp!=null)
                    {
                        JsonArray = new JArray();
                        JsonArray.Add(temp);
                        JSONDocumentMetaStructure.Add(JsonArray);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
             sb.Append(JsonConvert.SerializeObject(JSONDocumentMetaStructure, Formatting.Indented));

            string fileDirectory = System.IO.Path.GetDirectoryName(fileName);
            string fileTemplate = fileDirectory + @"\"+ DateTime.Now.ToString("yyyyMMddHHmmss") + "-add-template-"+ OrgName.Text + ".js";
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(fileTemplate))
            {
                file.WriteLine("\'use strict\';");
                file.WriteLine("const models = require('../models');");
                file.WriteLine("const Template = models.Template;");
                file.WriteLine("module.exports = {");
                file.WriteLine("up: (queryInterface, Sequelize) => {");
                file.WriteLine(" return Template.create({");
                file.WriteLine("id:"+ templateId +",");
                file.WriteLine("uuid: '" + Guid.NewGuid() +"',");
                file.Write("jsonTemplate: " + sb.ToString() + ",");
                file.WriteLine(" OrganizationId:,");
                file.WriteLine("isDefaultTemplate: true,");
                file.WriteLine("createdAt: new Date(),");
                file.WriteLine(" })");
                file.WriteLine(".then(() => {");
                file.WriteLine("console.log(`Added Template`);");
                file.WriteLine("})");
                file.WriteLine(".catch (error => {");
                file.WriteLine(" console.log(`ERROR ${ error}`);");
                file.WriteLine(" }); ");
                file.WriteLine("  },");
                file.WriteLine(" down: (queryInterface, Sequelize) => {");
                file.WriteLine("  return queryInterface.bulkDelete('Templates', null, { });");
                file.WriteLine(" },");
                file.WriteLine(" };");
               }
            int fileCount = 1;
            int ArrayNo = Convert.ToInt32(TemplateSections.Value);
           for (int i=0;i<JSONIndividualSeeders.Count;i= i+ArrayNo)
            {
                string fileTemplatesections = fileDirectory + @"\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-add-template-sections-" + OrgName.Text + "-"+ fileCount++ + ".js";
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(fileTemplatesections))
                {
                    file.WriteLine("\'use strict\';");
                    file.WriteLine("module.exports = {");
                    file.WriteLine("up: (queryInterface, Sequelize) => {");
                    file.WriteLine("  return queryInterface.bulkInsert('TemplateSections', [");
                    for(int k=0,j=k+i; (k < ArrayNo && j < JSONIndividualSeeders.Count); k++, j =k+i)
                    {
                        StringBuilder sb1 = new StringBuilder();
                        sb1.Append(JsonConvert.SerializeObject(JSONIndividualSeeders[j], Formatting.Indented));
                        file.WriteLine("{");
                        file.WriteLine("id:"+ templateSec++ +",");
                        file.WriteLine("uuid: '"+ JSONIndividualSeeders[j].sectionId+"',");
                        file.WriteLine("TemplateId:"+ templateId+", ");
                        file.Write("jsonSectionStruture:`"+ sb1.ToString()+"`,");
                        file.WriteLine("createdAt: new Date(),");
                        file.WriteLine("updatedAt: new Date(),");
                        file.WriteLine(" },");
                    }
                    file.WriteLine("  ]);");
                    file.WriteLine(" },");
                    file.WriteLine("down: (queryInterface, Sequelize) => {");
                    file.WriteLine("return queryInterface.bulkDelete('TemplateSections', null, { });");
                    file.WriteLine(" },");
                    file.WriteLine(" };");
                }

            }

        }
        string FetchValue(int CurrentRowNumber,decimal currentColumnNumber,bool isContent=false)
        {
            string returnvalue = "";
            returnvalue= Convert.ToString((range.Cells[CurrentRowNumber, currentColumnNumber] as Excel.Range).Value2);
            if(returnvalue==null)
            {
                returnvalue = "";
                if (isContent)
                {
                    returnvalue = "<p><br></p>";

                }
              
            }
            returnvalue = returnvalue.Trim().Replace("\n", "").Replace("\t", "");
            return returnvalue.Trim();
        }
        dynamic FetchSections(int order,int level)
        {
            dynamic section = new JObject();
            dynamic sectionTemp = new JObject();
            dynamic JARRAYOptions1 = null;
            dynamic JARRAYOptionsTemp = null;
            dynamic temp = null;
            int newLevel = level;
            int newOrder = order;
            string currentHeading = "";
           string currentSectionNumber = "";
            bool continueLoop = true;
            if (CurrentRowNumber <= TotalRowCount && CurrentRowNumber + 1 <= TotalRowCount)
            {
                ++CurrentRowNumber;
                section.sectionId = Guid.NewGuid();
                section.number = FetchValue(CurrentRowNumber, SectionNumber.Value);
                if(section.number=="none")
                {
                    section.number = "";
                }
                currentSectionNumber = FetchValue(CurrentRowNumber, SectionNumber.Value);
                section.title = FetchValue(CurrentRowNumber, SectionNames.Value);
                section.order = newOrder;
                section.level = newLevel;
                section.type = FetchValue(CurrentRowNumber, sectionType.Value);
                currentHeading = FetchValue(CurrentRowNumber, sectionType.Value);
                section.instructionText = "";
                section.exampleText = "";
                section.content = "";

                section.sections = new JArray();
                section.options = new JObject();
                sectionTemp.number = section.number;
                sectionTemp.sectionId = section.sectionId;
                sectionTemp.title = section.title;
                sectionTemp.order = section.order;
                sectionTemp.level = section.level;
                sectionTemp.instructionText = FetchValue(CurrentRowNumber, instructionText.Value);
                sectionTemp.exampleText = "";
                sectionTemp.options = new JObject();
                sectionTemp.type = section.type;

                if (currentHeading.ToUpper() == "HEADINGWITHFULLTEXT")
                {
                    newOrder = 1;
                    ++newLevel;
                    section.type = "Heading";
                    sectionTemp.type = "Heading";
                    
                    JARRAYOptions1 = new JObject();
                    JARRAYOptionsTemp = new JObject();

                    JARRAYOptions1.sectionId = Guid.NewGuid();
                    JARRAYOptionsTemp.sectionId = JARRAYOptions1.sectionId;
                    JARRAYOptionsTemp.number = "";
                    JARRAYOptionsTemp.type = "FullText";
                    JARRAYOptionsTemp.title = "";
                    JARRAYOptionsTemp.order = newOrder;
                    JARRAYOptionsTemp.level = newLevel;
                    JARRAYOptionsTemp.content = FetchValue(CurrentRowNumber, boliertext.Value,true);
                    JARRAYOptionsTemp.options = new JObject();
                    JARRAYOptionsTemp.instructionText = "";
                    JARRAYOptionsTemp.exampleText = FetchValue(CurrentRowNumber, exampleText.Value); ;
                    JARRAYOptions1.type = "FullText";
                    JARRAYOptions1.instructionText = "";
                    JARRAYOptions1.exampleText = "";
                    JARRAYOptions1.content = "";
                    JARRAYOptions1.options = new JObject();
                    JARRAYOptions1.sections = new JArray();
                    JARRAYOptions1.title = "";
                    JARRAYOptions1.order = newOrder;
                    JARRAYOptions1.number = "";
                    JARRAYOptions1.level = newLevel;
                    //section.type = (string)(range.Cells[CurrentRowNumber, sectionType.Value] as Excel.Range).Value2;
                    section.content = "";
                    section.sections.Add(JARRAYOptions1);
                    sectionTemp.content = "";
                    JSONIndividualSeeders.Add(sectionTemp);
                    JSONIndividualSeeders.Add(JARRAYOptionsTemp);
                }
                else if(currentHeading.ToUpper().Contains("METADATA"))
                {
                    int startIndex= currentHeading.IndexOf("(");
                    int endIndex = currentHeading.IndexOf(")");
                    string fieldName= currentHeading.Substring(startIndex + 1, endIndex - startIndex-1);
                    section.type = "MetaData";
                    sectionTemp.type = "MetaData";
                    section.options.field = fieldName;
                    sectionTemp.options.field = fieldName;
                    section.content = "";
                    sectionTemp.content = "";
                    sectionTemp.exampleText = FetchValue(CurrentRowNumber, exampleText.Value);
                    JSONIndividualSeeders.Add(sectionTemp);
                }
                else
                {
                    sectionTemp.content = FetchValue(CurrentRowNumber, boliertext.Value,true);
                    sectionTemp.exampleText = FetchValue(CurrentRowNumber, exampleText.Value);
                    JSONIndividualSeeders.Add(sectionTemp);
                }
               
                while (CurrentRowNumber <= TotalRowCount && CurrentRowNumber + 1 <= TotalRowCount && !currentSectionNumber.Contains("none") && continueLoop)
                {
                    string secNum = Convert.ToString((range.Cells[CurrentRowNumber + 1, SectionNumber.Value] as Excel.Range).Value2);
                    if(secNum.Contains(".") || secNum.Contains("none"))
                    {
                        if(secNum.Contains(".") && !currentSectionNumber.Contains("none"))
                        {
                            int ParentCOunt = currentSectionNumber.Split('.').Length - 1;
                            int childCount = secNum.Split('.').Length - 1;
                            if (ParentCOunt==childCount)
                            {
                                return section;
                            }
                            else if(childCount> ParentCOunt)
                            {
                                if (newLevel == level)
                                {
                                    ++newLevel;
                                    newOrder =1;
                                }
                                else
                                {
                                    ++newOrder;
                                }
                                temp = FetchSections(newOrder, newLevel);
                                if (temp != null)
                                {
                                    section.sections.Add(temp);
                                }
                            }
                            else
                            {
                                return section;
                            }
                        }
                        else if(secNum.Contains("none") && !currentSectionNumber.Contains("none"))
                        {
                            int ParentCOunt = currentSectionNumber.Split('.').Length - 1;
                            if (ParentCOunt==0)
                            {
                                if (newLevel == level)
                                {
                                    ++newLevel;
                                    newOrder = 0;
                                }
                                else
                                {
                                    ++newOrder;
                                }
                                temp = FetchSections(newOrder, newLevel);
                                if (temp != null)
                                {
                                    section.sections.Add(temp);
                                }
                            }
                            else
                            {
                                return section;
                            }
                        }                     
                       
                    }
                    else
                    {
                        return section;
                    }
                    
                }
            }
            return section;
        }


    }
}
