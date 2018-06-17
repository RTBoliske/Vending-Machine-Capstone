using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class Log
    {
        string sourceFilePath = "TransactionLog.txt";
        //sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);

        #region Members
       // private string _filePath = "";
        #endregion

        #region Properties
       // public string FilePath { get; }
        #endregion

        #region Constructor
        //public TransactionFileLog (string filePath)
        //{
        //    FilePath = filePath;
        //}
        #endregion

        #region Methods

        

        public void RecordCompleteTransaction (decimal initialAmount)
        {

        }
        public void RecordDeposit (decimal depositAmount,decimal finalBalance)
        {

        }
        public void RecordPurchase(string productName, string slotId, decimal initialBalance, decimal finalBalance)
        {

        }
        public void WriteTransaction(string message)
        {

        }
        #endregion
    }
}
