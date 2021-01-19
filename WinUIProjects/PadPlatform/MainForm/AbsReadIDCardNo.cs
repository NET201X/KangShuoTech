namespace KangShuo
{
    public abstract class AbsReadIDCardNo
    {
        public string idCardType;
        public bool IsOk;
        public string RdCardSN;
        public ReadCardEventHandler readCardEvent;

        protected AbsReadIDCardNo()
        {
        }

        public abstract bool CloseCard(out int p_ret);
        public abstract bool CloseShsCard(out int p_ret);
        public abstract void FreeIdCard();
        public abstract bool InitReadCard(out int p_ret);
        public abstract void StartRead();
        public abstract void StopRead();
    }
}

