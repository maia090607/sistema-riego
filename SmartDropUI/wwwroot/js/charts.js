window.chartInstances = {};

window.crearGraficaHumedad = function (labels, valores) {
    console.log('Creando gráfica de humedad', labels, valores);

    const ctx = document.getElementById('chartHumedadSuelo');
    if (!ctx) {
        console.error('Canvas no encontrado: chartHumedadSuelo');
        return;
    }

    if (window.chartInstances.humedad) {
        window.chartInstances.humedad.destroy();
    }

    window.chartInstances.humedad = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Humedad del Suelo (%)',
                data: valores,
                borderColor: '#10b981',
                backgroundColor: 'rgba(16, 185, 129, 0.1)',
                borderWidth: 3,
                tension: 0.4,
                fill: true,
                pointRadius: 5,
                pointBackgroundColor: '#10b981',
                pointBorderColor: '#fff',
                pointBorderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: true,
                    position: 'top'
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    max: 100,
                    ticks: {
                        callback: function (value) {
                            return value + '%';
                        }
                    }
                }
            }
        }
    });
};

window.crearGraficaTemperatura = function (labels, valores) {
    console.log('Creando gráfica de temperatura', labels, valores);

    const ctx = document.getElementById('chartTemperatura');
    if (!ctx) {
        console.error('Canvas no encontrado: chartTemperatura');
        return;
    }

    if (window.chartInstances.temperatura) {
        window.chartInstances.temperatura.destroy();
    }

    window.chartInstances.temperatura = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Temperatura (°C)',
                data: valores,
                borderColor: '#ef4444',
                backgroundColor: 'rgba(239, 68, 68, 0.1)',
                borderWidth: 3,
                tension: 0.4,
                fill: true,
                pointRadius: 5,
                pointBackgroundColor: '#ef4444',
                pointBorderColor: '#fff',
                pointBorderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: true,
                    position: 'top'
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    max: 40,
                    ticks: {
                        callback: function (value) {
                            return value + '°C';
                        }
                    }
                }
            }
        }
    });
};
