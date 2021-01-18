using ReportPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;

namespace printClass
{
    public class TransWord
    {
        public bool Convert(string sourcePath, string targetPath, Word.WdExportFormat exportFormat)
        {
            object _nullobj = System.Reflection.Missing.Value;
            bool result = false;
            int page = 0;
            object paramMissing = Type.Missing;
            object Nothing = System.Reflection.Missing.Value;
            Word.ApplicationClass wordApplication = new Word.ApplicationClass();
            Word.Document wordDocument = null;

            try
            {
                //DrawItems.WriteLog("Convert");
                object paramSourceDocPath = sourcePath;
                string paramExportFilePath = targetPath;

                Word.WdExportFormat paramExportFormat = exportFormat;
                bool paramOpenAfterExport = false;
                Word.WdExportOptimizeFor paramExportOptimizeFor =
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
                Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportFromTo;
                int paramStartPage = 1;
                int paramEndPage = 0;
                Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                Word.WdExportCreateBookmarks paramCreateBookmarks =
                        Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;
                wordDocument = wordApplication.Documents.Open(
                        ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing);

                if (wordDocument != null) page = wordDocument.ComputeStatistics(Word.WdStatistic.wdStatisticPages, ref _nullobj);

                if (page % 2 != 0)//删除最后一页空白页
                {
                    paramEndPage = page - 1;
                }
                else
                {
                    paramEndPage = page;
                }

                wordDocument.ExportAsFixedFormat(paramExportFilePath,
                            paramExportFormat, paramOpenAfterExport,
                            paramExportOptimizeFor, paramExportRange, paramStartPage,
                            paramEndPage, paramExportItem, paramIncludeDocProps,
                            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                            paramBitmapMissingFonts, paramUseISO19005_1,
                            ref paramMissing);
                result = true;
            }
            catch (Exception ex)
            {
                DrawItems.WriteLog(ex.ToString());

                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
                throw ex;
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }

                GC.Collect();
                //GC.WaitForPendingFinalizers();
            }

            return result;
        }

        public void PrintWord(string sourcePath, string targetPath)

        {
            Word.ApplicationClass word = new Word.ApplicationClass();

            Type wordType = word.GetType();



            //打开WORD文档 

            Word.Documents docs = word.Documents;

            Type docsType = docs.GetType();

            object objDocName = sourcePath;

            Word.Document doc = (Word.Document)docsType.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { objDocName, true, true });



            object printFileName = targetPath;


            //打印输出到指定文件 

            //可以使用 doc.PrintOut();方法,次方法调用中的参数设置较繁琐,建议使用 Type.InvokeMember 来调用时可以不用将PrintOut的参数设置全,只设置4个主要参数 

            Type docType = doc.GetType();
            docType.InvokeMember("PrintOut", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { false, false, Word.WdPrintOutRange.wdPrintAllDocument, printFileName });


            //退出WORD 

            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);

        }
    }
}
