namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [id] *long
    /// Table = probe.dbo.[p2_triggerlog]
    /// </summary>
    public class PbTriggerLog : TriggerLog
    {
                         
        #region Properties

        public virtual string DatabaseName { get; set; }
        public virtual string Key1Name { get; set; }
        public virtual string Key1Val { get; set; }
        public virtual string Key2Name { get; set; }
        public virtual string Key2Val { get; set; }
        public virtual string Key3Name { get; set; }
        public virtual string Key3Val { get; set; }
        
        //public virtual IPbAccount Account { get; set; }//on [KeyVal1]

        #endregion
                
    }
}