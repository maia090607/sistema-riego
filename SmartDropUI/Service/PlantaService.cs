using SmartDropUI.Models;

namespace SmartDropUI.Services
{
    public class PlantaService
    {
        private readonly HttpClient _httpClient;
        private const bool MODO_PRUEBA = true;

        // Lista simulada de plantas
        private static List<PlantaModel> plantasSimuladas = new List<PlantaModel>
        {
            new PlantaModel
            {
                Id = 1,
                Nombre = "Rosa Roja Premium",
                IdPlanta = "PLT001",
                Descripcion = "Rosa ornamental de jardín con flores rojas intensas. Requiere riego moderado y luz solar directa.",
                HumedadOptima = 70,
                TemperaturaOptima = 20,
                LuzOptima = "Media",
                ImagenUrl = "🌹",
                FechaRegistro = DateTime.Now.AddDays(-10)
            },
            new PlantaModel
            {
                Id = 2,
                Nombre = "Helecho Boston",
                IdPlanta = "PLT002",
                Descripcion = "Helecho de interior que requiere alta humedad y luz indirecta.",
                HumedadOptima = 80,
                TemperaturaOptima = 18,
                LuzOptima = "Baja",
                ImagenUrl = "🌿",
                FechaRegistro = DateTime.Now.AddDays(-5)
            },
            new PlantaModel
            {
                Id = 3,
                Nombre = "Cactus del Desierto",
                IdPlanta = "PLT003",
                Descripcion = "Cactus resistente que requiere poco riego y mucha luz solar.",
                HumedadOptima = 30,
                TemperaturaOptima = 25,
                LuzOptima = "Alta",
                ImagenUrl = "🌵",
                FechaRegistro = DateTime.Now.AddDays(-2)
            }
        };

        public PlantaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PlantaModel>> ObtenerPlantasAsync()
        {
            if (MODO_PRUEBA)
            {
                return await Task.FromResult(plantasSimuladas);
            }
            else
            {
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<List<PlantaModel>>("api/plantas");
                    return response ?? new List<PlantaModel>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener plantas: {ex.Message}");
                    return new List<PlantaModel>();
                }
            }
        }

        public async Task<PlantaModel?> ObtenerPlantaPorIdAsync(int id)
        {
            if (MODO_PRUEBA)
            {
                return await Task.FromResult(plantasSimuladas.FirstOrDefault(p => p.Id == id));
            }
            else
            {
                try
                {
                    return await _httpClient.GetFromJsonAsync<PlantaModel>($"api/plantas/{id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener planta: {ex.Message}");
                    return null;
                }
            }
        }

        public async Task<bool> RegistrarPlantaAsync(PlantaModel planta)
        {
            if (MODO_PRUEBA)
            {
                planta.Id = plantasSimuladas.Any() ? plantasSimuladas.Max(p => p.Id) + 1 : 1;
                planta.FechaRegistro = DateTime.Now;
                plantasSimuladas.Add(planta);
                return await Task.FromResult(true);
            }
            else
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("api/plantas", planta);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar planta: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<bool> ActualizarPlantaAsync(PlantaModel planta)
        {
            if (MODO_PRUEBA)
            {
                var plantaExistente = plantasSimuladas.FirstOrDefault(p => p.Id == planta.Id);
                if (plantaExistente != null)
                {
                    plantasSimuladas.Remove(plantaExistente);
                    plantasSimuladas.Add(planta);
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            else
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync($"api/plantas/{planta.Id}", planta);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar planta: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<bool> EliminarPlantaAsync(int id)
        {
            if (MODO_PRUEBA)
            {
                var planta = plantasSimuladas.FirstOrDefault(p => p.Id == id);
                if (planta != null)
                {
                    plantasSimuladas.Remove(planta);
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            else
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"api/plantas/{id}");
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar planta: {ex.Message}");
                    return false;
                }
            }
        }
    }
}