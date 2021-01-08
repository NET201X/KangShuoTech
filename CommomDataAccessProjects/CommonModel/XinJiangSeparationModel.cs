
using System.Collections.Generic;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class XinJiangSeparationModel
    {
        public MouthModel mouthList { get; set; }
    }

    public class MouthModel
    {
        public int ID { get; set; }

        public string IDCardNo { get; set; }

        public string RecordDate { get; set; }

        public string Lips { get; set; }

        public string ToothResides { get; set; }

        public string MissingTeeth { get; set; }

        public string Caries { get; set; }

        public string Denture { get; set; }

        public string Pharyngeal { get; set; }

        public string Listen { get; set; }

        public string LeftView { get; set; }

        public string RightView { get; set; }

        public string LeftEyecorrect { get; set; }

        public string RightEyecorrect { get; set; }
    }

    public class SurgicalModel
    {
        public string ID { get; set; }

        public string IDCardNo { get; set; }

        public string RecordDate { get; set; }

        public string SportFunction { get; set; }

        public string Skin { get; set; }

        public string SkinEx { get; set; }

        public string Sclera { get; set; }

        public string ScleraEx { get; set; }

        public string Lymph { get; set; }

        public string LymphEx { get; set; }

        public string PressPain { get; set; }

        public string PressPainEx { get; set; }

        public string EnclosedMass { get; set; }

        public string EnclosedMassEx { get; set; }

        public string Liver { get; set; }

        public string LiverEx { get; set; }

        public string Spleen { get; set; }

        public string SpleenEx { get; set; }

        public string Voiced { get; set; }

        public string VoicedEx { get; set; }

        public string Edema { get; set; }

        public string FootBack { get; set; }

        public string ElseDis { get; set; }

        public string ElseOther { get; set; }

        public string Other { get; set; }
    }

    public class InternalMedicineModel
    {
        public string ID { get; set; }

        public string IDCardNo { get; set; }

        public string RecordDate { get; set; }

        public string EyeRound { get; set; }
        public string EyeRoundEx { get; set; }
        public string BarrelChest { get; set; }
        public string BreathSounds { get; set; }
        public string BreathSoundsEx { get; set; }
        public string Rale { get; set; }
        public string RaleEx { get; set; }

        public string HeartRate { get; set; }

        public string HeartRhythm { get; set; }

        public string Noise { get; set; }

        public string NoiseEx { get; set; }

        public string Anus { get; set; }

        public string AnusEx { get; set; }

        public string Breast { get; set; }

        public string BreastEx { get; set; }

        public string Vulva { get; set; }

        public string VulvaEx { get; set; }

        public string Vagina { get; set; }

        public string VaginaEx { get; set; }

        public string CervixUteri { get; set; }

        public string CervixUteriEx { get; set; }

        public string Corpus { get; set; }

        public string CorpusEx { get; set; }

        public string Attach { get; set; }

        public string AttachEx { get; set; }
    }
}
