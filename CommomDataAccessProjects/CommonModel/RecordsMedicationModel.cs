namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class RecordsMedicationModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string UseAge { get; set; }
        public string UseNum { get; set; }
        public string Num { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PillDependence { get; set; }
        public string MedicinalName { get; set; }
        public string DrugType { get; set; }
        public string Factory { get; set; }
        public int OutKey { get; set; }
        public string Frequency { get; set; }
        public string UseNumUnit { get; set; }
        public string UseYear { get; set; }
        public string UseYearUnit { get; set; }
        public string OtherExplain { get; set; }
        public string NumUnit { get; set; }
        public string Remark { get; set; }
        public string DrugYear { get; set; }
        public string DrugMonth { get; set; }
        public string DrugDay { get; set; }
        public string FreUseNum { get; set; }
        public string FreUseDay { get; set; }
        public string UseDay { get; set; }
        public string Effect { get; set; }
        public string EffectDes { get; set; } 
        public string EachNum { get; set; }

        public RecordsStateModel ModelState { get; set; }
    }

    public class RecordsMediPhysDistModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        public string Mild { get; set; }
        public string Faint { get; set; }
        public string Yang { get; set; }
        public string Yin { get; set; }
        public string PhlegmDamp { get; set; }
        public string Muggy { get; set; }
        public string BloodStasis { get; set; }
        public string QiConstraint { get; set; }
        public string Characteristic { get; set; }
        public int OutKey { get; set; }
        public int MedicineID { get; set; }
        public int MedicineResultID { get; set; }
        public string MildOther { get; set; }
        public string FaintOther { get; set; }
        public string YangOther { get; set; }
        public string YinOther { get; set; }
        public string PhlegmDampOther { get; set; }
        public string MuggyOther { get; set; }
        public string BloodStasisOther { get; set; }
        public string QiConstraintOther { get; set; }
        public string CharacteristicOther { get; set; }
        public string ServerType { get; set; }

    }

    public class RecordsSignatureModel
    {
        public int ID { get; set; }
        public string PhysicalID { get; set; }
        public string IDCardNo { get; set; }
        /// <summary>
        /// ֢״ҽʦǩ��
        /// </summary>
        public string SymptomSn { get; set; }
        /// <summary>
        /// һ�����ҽʦǩ��
        /// </summary>
        public string GeneralConditionSn { get; set; }
        /// <summary>
        /// ���ʽҽʦǩ��
        /// </summary>
        public string LifeStyleSn { get; set; }
        /// <summary>
        /// ��������ҽʦǩ��
        /// </summary>
        public string OrgansFunctionSn { get; set; }
        /// <summary>
        /// ����_�۵�ҽʦǩ��
        /// </summary>
        public string PEyebseSn { get; set; }
        /// <summary>
        /// ����_Ƥ������Ĥ���ܰͽᡢ�Ρ����ࡢ��������֫ˮ�ס��㱳��������ҽʦǩ��
        /// </summary>
        public string PSkinSn { get; set; }
        /// <summary>
        /// ����_����ָ��ҽʦǩ��
        /// </summary>
        public string PDigtalExamSn { get; set; }
        /// <summary>
        /// ����_����ҽʦǩ��
        /// </summary>
        public string PBreastSn { get; set; }
        /// <summary>
        /// ����_����ҽʦǩ��
        /// </summary>
        public string PGynecologySn { get; set; }
        /// <summary>
        /// ����_����ҽʦǩ��
        /// </summary>
        public string PhysicalQtSn { get; set; }
        /// <summary>
        /// �������_Ѫ�͡�Ѫ����*���򳣹�*���ո�Ѫ��*��ͬ�Ͱ��װ���*ҽʦǩ��
        /// </summary>
        public string ABloodRoutineSn { get; set; }
        /// <summary>
        /// �������_��΢���׵���*�����ǱѪ*���ǻ�Ѫ�쵰��*�����͸��ױ��濹ԭ*�ι���*������*Ѫ֬*ҽʦǩ��
        /// </summary>
        public string AMAUSn { get; set; }
        /// <summary>
        /// �������_�ĵ�ͼ*ҽʦǩ��
        /// </summary>
        public string AECGSn { get; set; }
        /// <summary>
        /// �������_�ز�X��Ƭ*ҽʦǩ��
        /// </summary>
        public string AChestXraySn { get; set; }
        /// <summary>
        /// �������_����B��ҽʦǩ��
        /// </summary>
        public string ABtypeUltrasonicSn { get; set; }
        /// <summary>
        /// �������_B������ҽʦǩ��
        /// </summary>
        public string ABtypeQtSn { get; set; }
        /// <summary>
        /// �������_����ͿƬ*ҽʦǩ��
        /// </summary>
        public string ASmearSn { get; set; }
        /// <summary>
        /// �������_����ҽʦǩ��
        /// </summary>
        public string AssistQtSn { get; set; }
        /// <summary>
        /// �ִ���Ҫ����������סԺ�������ҽʦǩ��
        /// </summary>
        public string InpatientCareSn { get; set; }
        /// <summary>
        /// ��Ҫ��ҩ���������߹滮Ԥ������ʷҽʦǩ��
        /// </summary>
        public string DrugNonimmunitySn { get; set; }
        /// <summary>
        /// ��������ҽʦǩ��
        /// </summary>
        public string HealthAssessmentSn { get; set; }

        /// <summary>
        /// ����ָ��ҽʦǩ��
        /// </summary>
        public string HealthGuidanceSn { get; set; }
        /// <summary>
        /// ����ǩ��
        /// </summary>
        public string SelfSn { get; set; }
        /// <summary>
        /// ����ǩ��
        /// </summary>
        public string DependentSn { get; set; }
        /// <summary>
        /// ������ǩ��
        /// </summary>
        public string PersonalFb { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? FeedbackDate { get; set; }
        public int OutKey { get; set; }
    }
}