using PhysiotherapyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PhysiotherapyApp.Application.DTOs;
using PhysiotherapyApp.Application.Services;
using PhysiotherapyApp.Domain.Entities;

namespace PhysiotherapyApp.Application.Services
{
    internal class PatientService: IPatientService
    {  private readonly IUnitOfWork _unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PatientRespuestaDto>>
        ObtenerTodosAsync()
    {
        var patient = await _unitOfWork
            .Patient.ObtenerTodosAsync();

        return patient.Select(MapearRespuesta).ToList();
    }

    public async Task<PatientRespuestaDto?>
        ObtenerPorIdAsync(int id)
    {
        var client = await _unitOfWork
            .Patient.ObtenerPorIdAsync(id);

        if (client is null)
            return null;

        return MapearRespuesta(client);
    }

    public async Task<PatientRespuestaDto>
        CrearAsync(PatientCrearDto dto)
    {
        var existente = await _unitOfWork
            .Patient.ObtenerPorEmailAsync(dto.Email);

        if (existente is not null)
            throw new InvalidOperationException(
                "Ya existe un paciente con ese correo.");

        var patient= new Patient
        {
            FirstName = dto.Nombre,
            LastName = dto.Apellido,
            Email = dto.Email,
            DateOfBirth = dto.Edad
        };

        await _unitOfWork.Patient
            .AgregarAsync(patient);

        await _unitOfWork.SaveChangesAsync();

        return MapearRespuesta(patient);
    }

    public async Task<bool> ActualizarAsync(
        int id,
        PatientActualizarDto dto)
    {
        var patient = await _unitOfWork
            .Patient.ObtenerPorIdAsync(id);

        if (patient is null)
            return false;

        var anotherClient = await _unitOfWork
            .Patient.ObtenerPorEmailAsync(dto.Email);

        if (anotherClient is not null )
        {
            throw new InvalidOperationException(
                "El correo ya pertenece a otro estudiante.");
        }

            patient.FirstName = dto.Nombre;
            patient.LastName = dto.Apellido;
            patient.Email = dto.Email;
            patient.DateOfBirth = dto.Edad;

        _unitOfWork.Patient.Actualizar(patient);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var patient = await _unitOfWork
            .Patient.ObtenerPorIdAsync(id);

        if (patient is null)
            return false;

        _unitOfWork.Patient.Eliminar(patient);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    private static PatientRespuestaDto MapearRespuesta(
        Patient Patient)
    {
        return new PatientRespuestaDto
        {
            Id = Patient.Id,
            Nombre = Patient.FirstName,
            Apellido = Patient.LastName,
            Email = Patient.Email!,
            Edad = Patient.DateOfBirth
        };
    }
    }
}





  
