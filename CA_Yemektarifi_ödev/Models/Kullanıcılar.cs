using System;
using System.Collections.Generic;

namespace CA_Yemektarifi_ödev.Models;

public partial class Kullanıcılar
{
    public int Id { get; set; }

    public string Adı { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string? Şehirler { get; set; }

    public virtual ICollection<YemekTarifi> YemekTarifis { get; set; } = new List<YemekTarifi>();

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
