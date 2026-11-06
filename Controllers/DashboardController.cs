using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicalPanel.Api.Models;

namespace MedicalPanel.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize] // Sin token válido responde 401 Unauthorized automáticamente
public class DashboardController : ControllerBase
{
    [HttpGet("summary")]
    public ActionResult<DashboardSummary> GetSummary()
    {
        // Datos de ejemplo. Después se reemplazan por consultas a tu base de datos.
        var appointments = new List<UpcomingAppointment>
        {
            new(1, "09:00", "María López",    "Dr. Ramírez",  "Consulta general", "Confirmada"),
            new(2, "09:45", "Juan Pérez",     "Dra. Torres",  "Control de presión", "Confirmada"),
            new(3, "10:30", "Ana Gutiérrez",  "Dr. Ramírez",  "Revisión de estudios", "Pendiente"),
            new(4, "11:15", "Carlos Mendoza", "Dr. Herrera",  "Primera consulta", "Confirmada"),
            new(5, "12:00", "Lucía Ortega",   "Dra. Torres",  "Seguimiento", "Pendiente")
        };

        var alerts = new List<SystemAlert>
        {
            new(1, "Inventario", "alta",  "Paracetamol 500 mg: quedan solo 12 unidades"),
            new(2, "Inventario", "media", "Jeringas 5 ml por debajo del mínimo establecido"),
            new(3, "Recordatorio", "baja", "3 expedientes pendientes de completar")
        };

        var summary = new DashboardSummary(
            GeneratedAt: DateTime.Now,
            Metrics: new DashboardMetrics(
                TotalPatients: 1284,
                AppointmentsToday: appointments.Count,
                ActiveDoctors: 8),
            UpcomingAppointments: appointments.OrderBy(a => a.Time).ToList(),
            Alerts: alerts);

        return Ok(summary);
    }
}