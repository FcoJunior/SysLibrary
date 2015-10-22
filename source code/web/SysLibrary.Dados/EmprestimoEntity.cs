//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysLibrary.Dados
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmprestimoEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmprestimoEntity()
        {
            this.Devolucao = new HashSet<DevolucaoEntity>();
            this.Renovacao = new HashSet<RenovacaoEntity>();
        }
    
        public int Id { get; set; }
        public int LocacaoId { get; set; }
        public int ExemplarId { get; set; }
        public System.DateTime DataPrevistaDevolucao { get; set; }
        public bool Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DevolucaoEntity> Devolucao { get; set; }
        public virtual ExemplarEntity Exemplar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RenovacaoEntity> Renovacao { get; set; }
        public virtual LocacaoEntity Locacao { get; set; }
    }
}