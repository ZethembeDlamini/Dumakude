//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace guestHouse
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.roomBooks = new HashSet<roomBook>();
        }
    
        public int Id { get; set; }
        public string roomType { get; set; }
        public string roomDescription { get; set; }
        public Nullable<int> noOfBeds { get; set; }
        public string availability { get; set; }
        public string roomNo { get; set; }
        public string image { get; set; }
        public Nullable<int> price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<roomBook> roomBooks { get; set; }
    }
}
