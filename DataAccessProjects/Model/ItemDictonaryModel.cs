namespace KangShuoTech.DataAccessProjects.Model
{
    public class ItemDictonaryModel<T>
    {
        public ItemDictonaryModel(string displya, T valuemem)
        {
            this.DISPLAYMEMBER = displya;
            this.VALUEMEMBER = valuemem;
        }

        public string DISPLAYMEMBER { get; set; }

        public T VALUEMEMBER { get; set; }
    }
}

