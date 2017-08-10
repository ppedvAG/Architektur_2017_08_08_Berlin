namespace HalloReverceEngeneering
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produkte")]
    public partial class Produkte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produkte()
        {
            Kundens = new HashSet<Kunden>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kunden> Kundens { get; set; }
    }
}
