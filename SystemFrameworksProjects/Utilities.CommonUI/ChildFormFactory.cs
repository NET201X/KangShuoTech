namespace KangShuoTech.Utilities.CommonUI
{
    using System.Collections.Generic;

    public abstract class ChildFormFactory
    {
        protected ChildFormFactory()
        {
        }

        public abstract IChildForm CreateChildForm(string name);
        public virtual Dictionary<string, IChildForm> GetOneOrMoreForm()
        {
            return new Dictionary<string, IChildForm>();
        }

        public abstract List<ItemParamters> ItemParamters { get; set; }

        public abstract IMDIControler MControler { get; set; }

        public virtual string MDIFrmText { get; set; }
    }
}

