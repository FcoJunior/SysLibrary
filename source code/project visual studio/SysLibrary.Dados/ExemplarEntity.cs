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
    
    public partial class ExemplarEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExemplarEntity()
        {
            this.Emprestimo = new HashSet<EmprestimoEntity>();
        }
    
        public int Id { get; set; }
        public int ObraId { get; set; }
        public string Patrimonio { get; set; }
        public bool Status { get; set; }
        public System.DateTime DataCadastro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmprestimoEntity> Emprestimo { get; set; }
        public virtual ObraEntity Obra { get; set; }
    }
}
