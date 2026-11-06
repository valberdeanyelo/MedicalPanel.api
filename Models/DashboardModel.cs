namespace MedicalPanel.Api.Models;

public record DashboardMetrics(int TotalPatients, int AppointmentsToday, int ActiveDoctors);

public record UpcomingAppointment(int Id, string Time, string Patient, string Doctor, string Reason, string Status);

public record SystemAlert(int Id, string Type, string Severity, string Message);

public record DashboardSummary(
    DateTime GeneratedAt,
    DashboardMetrics Metrics,
    List<UpcomingAppointment> UpcomingAppointments,
    List<SystemAlert> Alerts);