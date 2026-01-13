using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class AdminController(TenderCareDbContext context) : Controller
    {
        // 1. PATIENTS (Admin Dashboard Main)
        public IActionResult Patients(string? searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var query = context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.PatientName.Contains(searchString) ||
                                         p.PatientID.Contains(searchString));
            }

            return View(query.OrderBy(p => p.PatientName).ToList());
        }

        // 2. APPOINTMENTS (ID, PatientID, ServiceType, Date, Status)
        public IActionResult Dashboard(string? searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var query = context.Appointments.Include(a => a.Patient).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.AppointmentID.Contains(searchString) ||
                                         a.PatientID.Contains(searchString));
            }

            return View(query.OrderByDescending(a => a.AppointmentDate).ToList());
        }

        // 3. IMMUNIZATION (ID, PatientID, Vaccine, Dose, Date, NextDue, Status)
        public IActionResult Immunization(string? searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var query = context.Immunizations.Include(i => i.Patient).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(i => i.PatientID.Contains(searchString) ||
                                         i.VaccineName.Contains(searchString));
            }

            return View(query.OrderByDescending(i => i.DateAdministered).ToList());
        }

        // 4. MEDICAL RECORDS
        public IActionResult MedicalRecords(string? searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var query = context.MedicalRecords.Include(m => m.Patient).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(r => r.RecordID.Contains(searchString) ||
                                         r.PatientID.Contains(searchString));
            }

            return View(query.OrderByDescending(r => r.DateRecorded).ToList());
        }
    }
}