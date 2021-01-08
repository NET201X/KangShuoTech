namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.InteropServices;

    public class FileSummary
    {
        public static void SetProperty(string filename, string msg, SummaryPropId summaryType)
        {
            IPropertySetStorage propertySetStorage = null;
            Guid riid = new Guid("0000013A-0000-0000-C000-000000000046");
            ole32.StgOpenStorageEx(filename, 0x12, 3, 0, IntPtr.Zero, IntPtr.Zero, ref riid, ref propertySetStorage);
            Guid rfmtid = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");
            IPropertyStorage propertyStorage = null;
            propertySetStorage.Create(ref rfmtid, IntPtr.Zero, 0, 0x1012, ref propertyStorage);
            PropSpec propertySpecification = new PropSpec {
                ulKind = 1,
                Name_Or_ID = new IntPtr((int) summaryType)
            };
            PropVariant propertyValues = new PropVariant();
            propertyValues.FromObject(msg);
            propertyStorage.WriteMultiple(1, ref propertySpecification, ref propertyValues, 2);
            propertyStorage.Commit(0);
            Marshal.ReleaseComObject(propertySetStorage);
            GC.Collect();
        }
    }
}

