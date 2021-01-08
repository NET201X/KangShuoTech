using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Windows.Documents;

namespace CommomUtilities.Common
{
    public interface IGetReport
    {
        string CardID { get; set; }

        string PrintType { get; set; }

        string Date { get; set; }

        string PrintName { get; }

        string VersionNo { get; set; }

        string Area { get; set; }

        string City { get; set; }

        string Community { get; set; }

        RecordsBaseInfoModel BaseModel { get; set; }

        bool hasData();

        FixedDocumentSequence getReport();
    }
}