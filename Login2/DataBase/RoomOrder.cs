//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login2.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomOrder
    {
        public int Idorder { get; set; }
        public int IdRoom { get; set; }
        public int ID { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Room Room { get; set; }
    }
}
