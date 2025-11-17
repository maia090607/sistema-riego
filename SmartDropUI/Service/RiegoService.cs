using SmartDropUI.Models;

namespace SmartDropUI.Service
{
    public class RiegoService
    {
        private List<DatosRiegoModel> historial = new List<DatosRiegoModel>();

        public RiegoService()
        {
            // Generar datos de ejemplo para el historial
            GenerarHistorialEjemplo();
        }

        public Task<DatosRiegoModel> ObtenerDatosRiego()
        {
            var datos = new DatosRiegoModel
            {
                Id = historial.Count + 1,
                Fecha = DateTime.Now,
                Temperatura = 90.8,
                HumedadAire = "H",
                Humedad = 75.0,
                BombaActiva = true,
                UltimoRiego = DateTime.Now.ToString("'Hoy' HH:mm"),
                Pronostico = "Despejado",
                Viento = "Norte",
                HumedadSuelo = "Humedad",
                Estado = "Activo"
            };

            return Task.FromResult(datos);
        }

        public Task<DatosRiegoModel> ObtenerDatosActualesAsync()
        {
            return ObtenerDatosRiego();
        }

        public Task<List<DatosRiegoModel>> ObtenerHistorial()
        {
            return Task.FromResult(historial);
        }

        public Task<List<DatosRiegoModel>> ObtenerHistorialAsync()
        {
            return Task.FromResult(historial);
        }

        public Task<bool> ActivarBomba()
        {
            return Task.FromResult(true);
        }

        public Task<bool> DesactivarBomba()
        {
            return Task.FromResult(true);
        }

        public async Task<bool> ActivarRiegoManualAsync()
        {
            // Crear un nuevo registro de riego
            var nuevoRiego = new DatosRiegoModel
            {
                Id = historial.Count + 1,
                Fecha = DateTime.Now,
                Temperatura = 90.8 + new Random().Next(-5, 5),
                HumedadAire = "H",
                Humedad = 75.0 + new Random().Next(-10, 10),
                BombaActiva = true,
                UltimoRiego = DateTime.Now.ToString("'Hoy' HH:mm"),
                Pronostico = "Despejado",
                Viento = "Norte",
                HumedadSuelo = "Humedad",
                Estado = "Activo"
            };

            historial.Insert(0, nuevoRiego);

            // Simular tiempo de riego
            await Task.Delay(1000);

            return true;
        }

        private void GenerarHistorialEjemplo()
        {
            var random = new Random();
            var estados = new[] { "Activo", "Completado", "Programado" };

            for (int i = 10; i >= 1; i--)
            {
                historial.Add(new DatosRiegoModel
                {
                    Id = 11 - i,
                    Fecha = DateTime.Now.AddDays(-i),
                    Temperatura = 85 + random.Next(-10, 15),
                    HumedadAire = random.Next(40, 80) + "%",
                    Humedad = 60 + random.Next(-15, 20),
                    BombaActiva = random.Next(0, 2) == 1,
                    UltimoRiego = DateTime.Now.AddDays(-i).ToString("dd/MM/yyyy HH:mm"),
                    Pronostico = random.Next(0, 2) == 1 ? "Despejado" : "Nublado",
                    Viento = new[] { "Norte", "Sur", "Este", "Oeste" }[random.Next(0, 4)],
                    HumedadSuelo = random.Next(50, 90) + "%",
                    Estado = estados[random.Next(0, estados.Length)]
                });
            }
        }
    }
}