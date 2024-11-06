using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace csharpbasic_interopService_demo
{
    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
    }
    internal class Program
    {
        static void TestExcelAcct()
        {
            var bankAcct = new List<Account>
            {
                new Account { ID = 12345, Balance = 99000.00 },
                new Account{ID=23456,Balance=199000.00},
                new Account{ID=34567,Balance=299000.00},

            };
            DisplayInExcel(bankAcct);
        }
        static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
            worksheet.Cells[1, "A"] = "ID Number";
            worksheet.Cells[1, "B"] = "Current Balance";
            var row = 1;
            foreach (var item in accounts)
            {
                row++;
                worksheet.Cells[row, "A"] = item.ID;
                worksheet.Cells[row, "B"] = item.Balance;
            }
            ((Excel.Range)worksheet.Columns[1]).AutoFit();
            ((Excel.Range)worksheet.Columns[2]).AutoFit();
        }
        static void TestWordApp()
        {
            var workApp = new Word.Application();
            workApp.Visible = true;
            workApp.Documents.Add();
            workApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            //// The Add method has four parameters, all of which are optional. 
            //// In Visual C# 2008 and earlier versions, an argument has to be sent 
            //// for every parameter. Because the parameters are reference  
            //// parameters of type object, you have to create an object variable
            //// for the arguments that represents 'no value'. 

            //object useDefaultValue = Type.Missing;

            //wordApp.Documents.Add(ref useDefaultValue, ref useDefaultValue,
            //    ref useDefaultValue, ref useDefaultValue);

            //// PasteSpecial has seven reference parameters, all of which are
            //// optional. In this example, only two of the parameters require
            //// specified values, but in Visual C# 2008 an argument must be sent
            //// for each parameter. Because the parameters are reference parameters,
            //// you have to contruct variables for the arguments.
            //object link = true;
            //object displayAsIcon = true;

            //wordApp.Selection.PasteSpecial(ref useDefaultValue,
            //                                ref link,
            //                                ref useDefaultValue,
            //                                ref displayAsIcon,
            //                                ref useDefaultValue,
            //                                ref useDefaultValue,
            //                                ref useDefaultValue);

        }
        static void Main(string[] args)
        {
            TestExcelAcct();//这个互操作速度比较慢,需要等待一下.生成的工作表不会自动保存.
            //TestWordApp();
        }
    }
}
