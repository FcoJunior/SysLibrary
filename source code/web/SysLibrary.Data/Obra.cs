//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysLibrary.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Obra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obra()
        {
            this.Exemplar = new HashSet<Exemplar>();
        }
    
        public int Id { get; set; }
        public int GeneroId { get; set; }
        public int EditoraId { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public int AutorId { get; set; }
    
        public virtual Autor Autor { get; set; }
        public virtual Editora Editora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exemplar> Exemplar { get; set; }
        public virtual Genero Genero { get; set; }
    }
}