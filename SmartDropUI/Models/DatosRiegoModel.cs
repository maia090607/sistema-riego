namespace SmartDropUI.Models
{
    public class DatosRiegoModel
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public double Humedad { get; set; }
    public double Temperatura { get; set; }
    public string Estado { get; set; } = string.Empty;
}

public class DatoGrafica
{
    public int Tiempo { get; set; }
    public double Valor { get; set; }
}
}