//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseDB
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Hall
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hall()
        {
            this.Exhibits = new ObservableCollection<Exhibit>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public int size_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Exhibit> Exhibits { get; set; }
        public virtual Size Size { get; set; }
    }
}