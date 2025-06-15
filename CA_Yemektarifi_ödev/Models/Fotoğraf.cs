using System;
using System.Collections.Generic;

namespace CA_Yemektarifi_ödev.Models;

public partial class Fotoğraf
{
    public int Id { get; set; }

    public string FotoUrl { get; set; } = null!;

    public string Açıklama { get; set; } = null!;

    public virtual ICollection<YemekTarifi> YemekTarifis { get; set; } = new List<YemekTarifi>();
}
