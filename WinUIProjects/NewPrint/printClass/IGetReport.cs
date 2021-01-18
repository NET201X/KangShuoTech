
using System.Windows.Documents;
using KangShuoTech.DataAccessProjects.Model;

namespace printClass
{
	public interface IGetReport
	{
		string CardID
		{
			get;
			set;
		}
		string PrintName
		{
			get;
		}
        RecordsBaseInfoModel BaseModel
		{
			get;
			set;
		}
		bool hasData();
		FixedDocumentSequence getReport();
	}
}
