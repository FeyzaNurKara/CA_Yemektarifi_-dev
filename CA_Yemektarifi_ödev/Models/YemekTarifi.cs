using System;
using System.Collections.Generic;

namespace CA_Yemektarifi_ödev.Models;

public partial class YemekTarifi
{
    public int Id { get; set; }

    public string YemekAdı { get; set; } = null!;

    public string Tarif { get; set; } = null!;

    public int? FotoId { get; set; }

    public int YorumId { get; set; }

    public int YükleyenKullanıcıId { get; set; }

    public virtual Fotoğraf? Foto { get; set; }

    public virtual Yorumlar Yorum { get; set; } = null!;

    public virtual Kullanıcılar YükleyenKullanıcı { get; set; } = null!;
}
