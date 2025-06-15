using System;
using System.Collections.Generic;

namespace CA_Yemektarifi_ödev.Models;

public partial class Yorumlar
{
    public int Id { get; set; }

    public int KullanıcıId { get; set; }

    public string Metin { get; set; } = null!;

    public DateTime YorumTarihi { get; set; }

    public virtual Kullanıcılar Kullanıcı { get; set; } = null!;

    public virtual ICollection<YemekTarifi> YemekTarifis { get; set; } = new List<YemekTarifi>();
}
