using System;

public class Venta
{
    private int Id { get; set; }
    private string Comentarios { get; set; }

    public Venta(int id, string comentarios)
    {
        Id = id;
        Comentarios = comentarios;
    }
}
