public class Estudiante
{
	public int Id { get; set; }
	public string Nombre { get; set; }
	public string Apellido { get; set; }
	public string Correo { get; set; }
	public string ContraseñaHash { get; set; }
	public bool Estatus { get; set; }
	public DateTime FechaCreacion { get; set; }
	public DateTime FechaActualizacion { get; set; }
	public DateTime UltimoAcesso { get; set; }
}