using System;
using Zen.Core.Components;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [idx]
    /// Table = probe.dbo.[p2_wrk_plx]
    /// </summary>
    public class PbWorkPlacement : WorkPlacement
    {        
        public virtual string DODVerifInitials { get; set; }
        public virtual string DODVerifSource { get; set; }                
        public virtual string Informant { get; set; }
        public virtual string InformantPhone { get; set; }
        public virtual string MatterNum { get; set; }
        public virtual string UD11 { get; set; }
        public virtual string UD12 { get; set; }
        public virtual string UD13 { get; set; }
        public virtual string UD14 { get; set; }
        public virtual string UD15 { get; set; }
        public virtual string UD16 { get; set; }
        public virtual string UD17 { get; set; }
        public virtual string UD18 { get; set; }
        public virtual string UD19 { get; set; }
        public virtual string UD20 { get; set; }
        public virtual string UD21 { get; set; }
        public virtual string UD22 { get; set; }
        public virtual string UD23 { get; set; }
        public virtual string UD24 { get; set; }
        public virtual string UD25 { get; set; }
        public virtual DateTime? DOD { get; set; }
        public virtual DateTime? DODVerifDate { get; set; }
        public virtual ContactInfo Executor { get; set; }
        #region using components...
        /*public virtual string AttyAddress { get; set; }  
        public virtual string ExecAddress { get; set; }
        public virtual string ExecCity { get; set; }
        public virtual string ExecEmail { get; set; }
        public virtual string ExecFax { get; set; }
        public virtual string ExecName { get; set; }
        public virtual string ExecPhone { get; set; }
        public virtual string ExecState { get; set; }
        public virtual string ExecZip { get; set; }*/
        #endregion

    }
}